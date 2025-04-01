using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace APB.AccessControl.Application.Services
{
    public class AccessPointService : IAccessPointService
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessPointService> _logger;

        public AccessPointService(
            IAccessPointRepository accessPointRepository,
            IMapper mapper,
            ILogger<AccessPointService> logger)
        {
            _accessPointRepository = accessPointRepository
                ?? throw new ArgumentNullException(nameof(accessPointRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessPointDto> CreateAsync(CreateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<AccessPoint>(request);
                var repResponse = await _accessPointRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<AccessPointDto>(repResponse);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessPointRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                await _accessPointRepository.DeleteAsync(id, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<AccessPointDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _accessPointRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessPointDto>>(repResponse);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessPointDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _accessPointRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                return _mapper.Map<AccessPointDto>(repResponse);
            }, nameof(GetByIdAsync));
        }

        public async Task UpdateAsync(UpdateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessPointRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(AccessPoint));

                var repReq = _mapper.Map<AccessPoint>(request);
                await _accessPointRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }
    }
}
