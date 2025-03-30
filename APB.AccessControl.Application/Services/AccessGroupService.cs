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
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using static APB.AccessControl.Application.Common.Extensions;

namespace APB.AccessControl.Application.Services
{
    public class AccessGroupService: IAccessGroupService
    {
        private readonly IAccessGroupRepository _accessGroupRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessGroupService> _logger;

        public AccessGroupService(
            IAccessGroupRepository accessGroupRepository, 
            IMapper mapper, 
            IEmployeeRepository employeeRepository,
            ILogger<AccessGroupService> logger)
        {
            _accessGroupRepository = accessGroupRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        #region CRUD
        public async Task<AccessGroupDto> CreateAsync(CreateGroupReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<AccessGroup>(request);
                var repRes = await _accessGroupRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<AccessGroupDto>(repRes);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), id);

                await _accessGroupRepository.DeleteAsync(id, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<AccessGroupDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessGroupRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessGroupDto>>(repRes);
            }, nameof(GetAllAsync));
        }

        public async Task UpdateAsync(UpdateGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.Id);

                var repReq = _mapper.Map<AccessGroup>(request);
                await _accessGroupRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }
        #endregion

        public async Task AddEmployeeToGroupAsync(AddEmployeeToGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(request.GroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.GroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                await _accessGroupRepository.AssignEmployeeToGroupAsync(request.EmployeeId, request.GroupId, cancellationToken);
            }, nameof(AddEmployeeToGroupAsync));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesInGroupAsync(int groupId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(groupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), groupId);

                var repRes = await _accessGroupRepository.GetEmployeesByGroupIdAsync(groupId, cancellationToken);
                return _mapper.Map<IEnumerable<EmployeeDto>>(repRes);
            }, nameof(GetEmployeesInGroupAsync));
        }

        public async Task RemoveEmployeeFromGroupAsync(RemoveEmployeeFromGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(request.GroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.GroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                await _accessGroupRepository.RemoveEmployeeFromGroupAsync(request.EmployeeId, request.GroupId, cancellationToken);
            }, nameof(RemoveEmployeeFromGroupAsync));
        }

        public async Task<IEnumerable<int>> GetGroupIdByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                if (!await _employeeRepository.ExistsAsync(employeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), employeeId);

                var groups = await _accessGroupRepository.GetGroupsByEmployeeIdAsync(employeeId, cancellationToken);
                return groups.Select(g => g.Id);
            }, nameof(GetGroupIdByEmployeeIdAsync));
        }
    }
}
