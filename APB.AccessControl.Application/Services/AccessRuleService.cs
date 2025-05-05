using APB.AccessControl.Application.Common;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Application.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Application.Filters;

namespace APB.AccessControl.Application.Services
{   
    public class AccessRuleService : IAccessRuleService
    {
        private readonly IAccessRuleRepository _accessRuleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessRuleService> _logger;

        public AccessRuleService(
            IAccessRuleRepository accessRuleRepository,
            IMapper mapper,
            ILogger<AccessRuleService> logger)
        {
            _accessRuleRepository = accessRuleRepository 
                ?? throw new ArgumentNullException(nameof(accessRuleRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessRuleDto> CreateAsync(CreateAccessRuleReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<AccessRule>(request);
                await _accessRuleRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<AccessRuleDto>(repReq);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var entity = await _accessRuleRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessRule), nameof(AccessRule.Id), id);

                await _accessRuleRepository.DeleteAsync(entity, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<AccessRuleDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessRuleRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessRule), nameof(AccessRule.Id), id);

                return _mapper.Map<AccessRuleDto>(repRes);
            }, nameof(GetByIdAsync));
        }

        public async Task<IEnumerable<AccessRuleDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessRuleRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessRuleDto>>(repRes);
            }, nameof(GetAllAsync));
        }

        public async Task UpdateAsync(UpdateAccessRuleReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessRuleRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(AccessRule), nameof(AccessRule.Id), request.Id);

                var repReq = _mapper.Map<AccessRule>(request);
                await _accessRuleRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }

        public async Task<IEnumerable<AccessRuleDto>> GetByFilterAsync(AccessRuleFilter filter = default, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessRuleRepository.GetByFilterAsync(filter, cancellationToken);
                return _mapper.Map<IEnumerable<AccessRuleDto>>(repRes);
            }, nameof(GetByFilterAsync));
        }
    }
}
