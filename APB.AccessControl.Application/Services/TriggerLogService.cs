using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.Requests;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.Application.Services
{
    public class AccessTriggerLogService : IAccessTriggerLogService
    {
        private readonly IAccessTriggerLogRepository _triggerLogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessTriggerLogService> _logger;

        public AccessTriggerLogService(
            IAccessTriggerLogRepository triggerLogRepository,
            IMapper mapper, 
            ILogger<AccessTriggerLogService> logger)
        {
            _triggerLogRepository = triggerLogRepository 
                ?? throw new ArgumentNullException(nameof(triggerLogRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public async Task<IEnumerable<AccessTriggerLogDto>> GetTriggerLogsByFilter(AccessTriggerLogFilter filter = null, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _triggerLogRepository.GetByFilterAsync(filter, cancellationToken);
                return _mapper.Map<IEnumerable<AccessTriggerLogDto>>(repResponse);
            }, nameof(GetTriggerLogsByFilter));
        }

        public Task LogAccessTriggerExecutionAsync(CreateAccessTriggerLogReq request, CancellationToken cancellationToken = default)
        {
            return _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<AccessTriggerLog>(request);
                await _triggerLogRepository.AddAsync(repReq, cancellationToken);
            }, nameof(LogAccessTriggerExecutionAsync));
        }
    }
}
