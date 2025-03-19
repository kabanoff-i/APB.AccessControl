using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services
{
    public class AccessPointService : IAccessPointService
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly IMapper _mapper;

        public AccessPointService(IAccessPointRepository accessPointRepository, IMapper mapper)
        {
            _accessPointRepository = accessPointRepository ?? throw new ArgumentNullException(nameof(accessPointRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AccessPointDto> CreateAsync(CreateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var repReq = _mapper.Map<AccessPoint>(request);
                var repRes = await _accessPointRepository.AddAsync(repReq, cancellationToken);

                return _mapper.Map<AccessPointDto>(repRes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(UpdateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _accessPointRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), request.Id);

                var repReq = _mapper.Map<AccessPoint>(request);
                await _accessPointRepository.UpdateAsync(repReq, cancellationToken);
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
                if (!await _accessPointRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                await _accessPointRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<AccessPointDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _accessPointRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessPointDto>>(repRes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AccessPointDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _accessPointRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                return _mapper.Map<AccessPointDto>(repRes);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
