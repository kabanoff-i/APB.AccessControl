using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace APB.AccessControl.Application.Services
{
    public class TriggerService : ITriggerService
    {
        private readonly ITriggerRepository _triggerRepository;
        private readonly IAccessLogRepository _accessLogRepository;
        private readonly IAccessTriggerLogService _accessTriggerLogService;
        private readonly ITriggerExecuter _triggerExecuter;
        private readonly IMapper _mapper;

        public TriggerService(
            ITriggerRepository triggerRepository,
            IAccessLogRepository accessLogRepository,
            IAccessTriggerLogService accessTriggerLogService,
            ITriggerExecuter triggerExecuter,
            IMapper mapper)
        {
            _triggerRepository = triggerRepository 
                ?? throw new ArgumentNullException(nameof(triggerRepository));
            _accessLogRepository = accessLogRepository 
                ?? throw new ArgumentNullException(nameof(accessLogRepository));
            _accessTriggerLogService = accessTriggerLogService 
                ?? throw new ArgumentNullException(nameof(accessTriggerLogService));
            _triggerExecuter = triggerExecuter
                ?? throw new ArgumentNullException(nameof(triggerExecuter));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ExecuteTriggersAsync(Guid accessLogId, CancellationToken cancellationToken = default)
        {
            try
            {
                // 1. Найти запись в логах доступа
                var accessLog = await _accessLogRepository.GetByIdAsync(accessLogId, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessLog), nameof(AccessLog.Id), accessLogId);

                // 2. Получить триггеры, связанные с пропускным пунктом (AccessPointId)
                var triggers = await _triggerRepository.GetTriggersForAccessPointAsync(accessLog.AccessPointId, cancellationToken);

                if (!triggers.Any())
                    return;

                // 3. Выполнить каждый триггер
                foreach (var trigger in triggers)
                {
                    await ExecuteTriggerAsync(trigger, accessLog, cancellationToken);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task ExecuteTriggerAsync(Trigger trigger, AccessLog accessLog, CancellationToken cancellationToken)
        {
            try
            {
                // Здесь кастомная логика выполнения триггера, зависит от типа ActionType
                // Например, отправка уведомлений, включение/выключение системы и т. д.
                await _triggerExecuter.ExecuteAsync(trigger, cancellationToken);

                // 4. Логируем выполнение триггера
                var logEntry = new CreateAccessTriggerLogReq
                {
                    AccessLogId = accessLog.Id,
                    TriggerId = trigger.Id,
                    ExecutedAt = DateTime.UtcNow
                };

                await _accessTriggerLogService.LogAccessTriggerExecutionAsync(logEntry, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TriggerDto> CreateAsync(CreateTriggerReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var trigger = _mapper.Map<Trigger>(request);
                var created = await _triggerRepository.AddAsync(trigger, cancellationToken);
                return _mapper.Map<TriggerDto>(created);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(UpdateTriggerReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var trigger = await _triggerRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Trigger), nameof(Trigger.Id), request.Id);

                _mapper.Map(request, trigger);
                await _triggerRepository.UpdateAsync(trigger, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await _triggerRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TriggerDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var triggers = await _triggerRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<TriggerDto>>(triggers);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
