using APB.AccessControl.Application.Filters;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Exceptions;

namespace APB.AccessControl.Application.Services
{
    public class AccessLogService : IAccessLogService
    {
        private readonly IAccessLogRepository _accessLogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessLogService> _logger;

        public AccessLogService(
            IAccessLogRepository accessLogRepository, 
            IMapper mapper,
            ILogger<AccessLogService> logger)
        {
            _accessLogRepository = accessLogRepository 
                ?? throw new ArgumentNullException(nameof(accessLogRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessLogDto> LogAccessAttemptAsync(CreateAccessLogReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                if (request == null) 
                    throw new ArgumentNullException(nameof(request));

                var accessLog = _mapper.Map<AccessLog>(request);
                var repResponse = await _accessLogRepository.AddAsync(accessLog, cancellationToken);
                return _mapper.Map<AccessLogDto>(repResponse);
            }, nameof(LogAccessAttemptAsync));
        }

        public async Task<IEnumerable<AccessLogDto>> GetLogsByFilterAsync(AccessLogFilter filter = default, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var logs = await _accessLogRepository.GetByFilterAsync(filter, cancellationToken);
                return _mapper.Map<IEnumerable<AccessLogDto>>(logs);
            }, nameof(GetLogsByFilterAsync));
        }

        public async Task<AccessLogDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var accessLog = await _accessLogRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessLog), nameof(AccessLog.Id), id);
                return _mapper.Map<AccessLogDto>(accessLog);
            }, nameof(GetByIdAsync));
        }
    }
}
