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

namespace APB.AccessControl.Application.Services
{
    public class AccessCheckService: IAccessCheckService
    {
        private readonly ICardService _cardService;
        private readonly IAccessRuleService _accessRuleService;
        private readonly IAccessGroupService _accessGroupService;
        private readonly IAccessLogService _accessLogService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<AccessCheckService> _logger;

        public AccessCheckService(
            IAccessRuleService accessRuleService,
            ICardService cardService,
            IAccessGroupService accessGroupService,
            IAccessLogService accessLogService,
            IEmployeeService employeeService,
            ILogger<AccessCheckService> logger)
        {
            _accessRuleService = accessRuleService
                ?? throw new ArgumentNullException(nameof(accessRuleService));
            _cardService = cardService
                ?? throw new ArgumentNullException(nameof(cardService));
            _accessGroupService = accessGroupService
                ?? throw new ArgumentNullException(nameof(accessGroupService));
            _accessLogService = accessLogService
                ?? throw new ArgumentNullException(nameof(accessLogService));
            _employeeService = employeeService
                ?? throw new ArgumentNullException(nameof(employeeService));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessCheckResponse> CheckAccessAsync(CheckAccessReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                // Проверяем существование и активность карты
                var card = await _cardService.GetCardByHashAsync(request.CardHash, cancellationToken);
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
                var employee = await _employeeService.GetEmployeeByIdAsync(card.EmployeeId, cancellationToken);
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
                        Message = "Сотрудник не найден",
                        CardId = card.Id
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
                        EmployeeId = employee.Id,
                        CardId = card.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        PassportNumber = employee.PassportNumber,
                        Photo = Convert.ToBase64String(employee.Photo)
                    };
                }

                // Получаем группы доступа сотрудника
                var employeeGroups = await _accessGroupService.GetGroupIdByEmployeeIdAsync(card.EmployeeId, cancellationToken);
                if (!employeeGroups.Any())
                {
                    await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                    {
                        CardId = card.Id,
                        EmployeeId = card.EmployeeId,
                        AccessPointId = request.AcсessPointId,
                        DateAccess = request.DateAccess,
                        AccessResult = (int)AccessResult.Denied,
                        Message = "Отсутствуют группы доступа"
                    }, cancellationToken);

                    return new AccessCheckResponse
                    {
                        IsSuccess = false,
                        Message = "У сотрудника отсутствуют группы доступа",
                        EmployeeId = employee.Id,
                        CardId = card.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        PassportNumber = employee.PassportNumber,
                        Photo = Convert.ToBase64String(employee.Photo)
                    };
                }

                // Проверяем наличие доступа хотя бы в одной группе
                var hasAccess = false;
                foreach (var groupId in employeeGroups)
                {
                    if (await _accessRuleService.CheckAccessByGroupIdAsync(groupId, cancellationToken))
                    {
                        hasAccess = true;
                        break;
                    }
                }

                var accessResult = hasAccess ? AccessResult.Granted : AccessResult.Denied;
                var message = hasAccess ? "Доступ разрешен" : "Нет прав доступа к данной точке пропуска";

                await _accessLogService.LogAccessAttemptAsync(new CreateAccessLogReq
                {
                    CardId = card.Id,
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
                    EmployeeId = employee.Id,
                    CardId = card.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PassportNumber = employee.PassportNumber,
                    Photo = Convert.ToBase64String(employee.Photo)
                };
            }, nameof(CheckAccessAsync));
        }
    }
}
