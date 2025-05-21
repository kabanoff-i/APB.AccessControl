using APB.AccessControl.Application.Common;
using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services
{
    public class AccessPointTypeService : IAccessPointTypeService
    {
        private readonly IAccessPointTypeRepository _accessPointTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessPointTypeService> _logger;

        public AccessPointTypeService(
            IAccessPointTypeRepository accessPointTypeRepository,
            IMapper mapper,
            ILogger<AccessPointTypeService> logger)
        {
            _accessPointTypeRepository = accessPointTypeRepository 
                ?? throw new ArgumentNullException(nameof(accessPointTypeRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<AccessPointTypeDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var accessPointTypes = await _accessPointTypeRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessPointTypeDto>>(accessPointTypes);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessPointTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var accessPointType = await _accessPointTypeRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPointType), nameof(AccessPointType.Id), id);

                return _mapper.Map<AccessPointTypeDto>(accessPointType);
            }, nameof(GetByIdAsync));
        }
    }
} 