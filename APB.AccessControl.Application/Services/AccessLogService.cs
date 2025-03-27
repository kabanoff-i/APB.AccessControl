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

namespace APB.AccessControl.Application.Services
{
    public class AccessLogService : IAccessLogService
    {
        private readonly IAccessLogRepository _accessLogRepository;
        private readonly IMapper _mapper;

        public AccessLogService(IAccessLogRepository accessLogRepository, IMapper mapper)
        {
            _accessLogRepository = accessLogRepository 
                ?? throw new ArgumentNullException(nameof(accessLogRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AccessLogDto> LogAccessAttemptAsync(CreateAccessLogReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));

                var accessLog = _mapper.Map<AccessLog>(request);
                var repResponse = await _accessLogRepository.AddAsync(accessLog, cancellationToken);

                var response = _mapper.Map<AccessLogDto>(repResponse);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AccessLogDto>> GetLogsByFilterAsync(AccessLogFilter filter = default, CancellationToken cancellationToken = default)
        {
            try
            {
                var logs = await _accessLogRepository.GetLogsByFilterAsync(filter, cancellationToken);
                return _mapper.Map<IEnumerable<AccessLogDto>>(logs);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
