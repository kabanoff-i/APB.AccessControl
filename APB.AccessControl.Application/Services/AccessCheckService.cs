using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System;
using APB.AccessControl.Shared.Models.Responses;
using System.Collections.Generic;
using System.Linq;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Application.Filters;
using static APB.AccessControl.Shared.Extensions;
using APB.AccessControl.Application.Interfaces;

namespace APB.AccessControl.Application.Services
{
    public class AccessCheckService: IAccessCheckService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccessRuleRepository _accessRuleRepository;
        private readonly IAccessGroupRepository _accessGroupRepository;
        private readonly IAccessGridRepository _accessGridRepository;
        private readonly IAccessLogService _accessLogService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessCheckService> _logger;

        public AccessCheckService(
            IAccessRuleRepository accessRuleRepository,
            ICardRepository cardRepository,
            IAccessGroupRepository accessGroupRepository,
            IAccessGridRepository accessGridRepository,
            IAccessLogService accessLogService,
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            ILogger<AccessCheckService> logger)
        {
            _accessRuleRepository = accessRuleRepository
                ?? throw new ArgumentNullException(nameof(accessRuleRepository));
            _cardRepository = cardRepository
                ?? throw new ArgumentNullException(nameof(cardRepository));
            _accessGroupRepository = accessGroupRepository
                ?? throw new ArgumentNullException(nameof(accessGroupRepository));
            _accessGridRepository = accessGridRepository
                ?? throw new ArgumentNullException(nameof(accessGridRepository));
            _accessLogService = accessLogService
                ?? throw new ArgumentNullException(nameof(accessLogService));
            _employeeRepository = employeeRepository
                ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        private bool IsAccessRuleMatch(CheckAccessReq request, AccessRule rule)
        {
            // Проверяем активность правила
            if (!rule.IsActive)
                return false;

            // Проверяем точку доступа
            if (rule.AccessPointId != request.AcсessPointId)
                return false;

            // Проверяем срок действия правила
            if (request.DateAccess < rule.StartDate || request.DateAccess > rule.EndDate)
                return false;

            // Проверяем день недели
            var dayOfWeek = (int)request.DateAccess.DayOfWeek;
            if (!rule.DaysOfWeek[dayOfWeek])
                return false;

            // Проверяем время
            var timeOfDay = request.DateAccess.TimeOfDay;
            if (timeOfDay < rule.AllowedTimeStart || timeOfDay > rule.AllowedTimeEnd)
                return false;

            // Проверяем специальные даты если они заданы
            if (!string.IsNullOrEmpty(rule.SpecificDates))
            {
                var specificDates = rule.SpecificDates.DeserializeJson<DateTime[]>();
                if (specificDates.Any(d => d.Date == request.DateAccess.Date))
                    return false;
            }

            return true;
        }
        
        public async Task<AccessCheckResponse> CheckAccessAsync(CheckAccessReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                // Проверяем существование и активность карты
                var card = await _cardRepository.GetByHashAsync(request.CardHash, cancellationToken);
                if (card == null)
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardHash = request.CardHash,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = $"Карта с хэшем {request.CardHash} не найдена"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = $"Карта с хэшем {request.CardHash} не найдена"
                    };
                }

                // Получаем информацию о сотруднике
                var employee = await _employeeRepository.GetByIdAsync(card.EmployeeId, cancellationToken);
                if (employee == null)
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardId = card.Id,
                        CardHash = request.CardHash,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = "Сотрудник не найден"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = "Сотрудник не найден"
                    };
                }

                if (!employee.IsActive)
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardId = card.Id,
                        EmployeeId = card.EmployeeId,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = "Сотрудник не активен"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = "Сотрудник не активен",
                        Employee = _mapper.Map<EmployeeDto>(employee)
                    };
                }

                if (!card.IsActive)
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardId = card.Id,
                        EmployeeId = card.EmployeeId,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = "Карта деактивирована"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = "Карта деактивирована",
                        Employee = _mapper.Map<EmployeeDto>(employee)
                    };
                }

                // Получаем группы доступа сотрудника
                var accessGrids = await _accessGridRepository.GetByEmployeeIdAsync(card.EmployeeId, cancellationToken);
                var employeeGroups = accessGrids.Where(x => x.IsActive).Select(g => g.AccessGroup);

                if (!employeeGroups.Any(x => x.IsActive))
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardId = card.Id,
                        EmployeeId = card.EmployeeId,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = "Отсутствуют активные группы доступа"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = "У сотрудника отсутствуют активные группы доступа",
                        Employee = _mapper.Map<EmployeeDto>(employee)
                    };
                }

                // Проверяем наличие доступа хотя бы в одной группе
                var hasAccess = false;
                foreach (var group in employeeGroups)
                {
                    var rules = await _accessRuleRepository.GetByFilterAsync(new AccessRuleFilter
                    {
                        AccessGroupId = group.Id,
                        AccessPointId = request.AcсessPointId
                    }, cancellationToken);

                    // Проверяем каждое активное правило на соответствие времени и дате
                    foreach (var rule in rules.Where(r => r.IsActive))
                    {
                        if (IsAccessRuleMatch(request, rule))
                        {
                            hasAccess = true;
                            break;
                        }
                    }

                    if (hasAccess)
                        break;
                }

                var accessResult = hasAccess ? AccessResult.Granted : AccessResult.Denied;
                var message = hasAccess ? "Доступ разрешен" : "Нет прав доступа к данной точке пропуска";

                await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                {
                    CardId = card.Id,
                    CardHash = request.CardHash,
                    EmployeeId = card.EmployeeId,
                    AccessPointId = request.AcсessPointId,
                    DateAccess = request.DateAccess,
                    AccessResult = (int)accessResult,
                    Message = message
                }, cancellationToken);

                return new AccessCheckResponse 
                { 
                    IsSuccess = hasAccess,
                    Message = message,
                    Employee = _mapper.Map<EmployeeDto>(employee)
                };
            }, nameof(CheckAccessAsync));
        }
    }
}
