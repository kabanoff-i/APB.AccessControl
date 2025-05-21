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
using APB.AccessControl.Application.Validators;
using FluentValidation;

namespace APB.AccessControl.Application.Services
{
    public class AccessGroupService: IAccessGroupService
    {
        private readonly IAccessGroupRepository _accessGroupRepository;
        private readonly IAccessGridRepository _accessGridRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessGroupService> _logger;
        private readonly AccessGroupValidator _accessGroupValidator;

        public AccessGroupService(
            IAccessGroupRepository accessGroupRepository, 
            IMapper mapper, 
            IEmployeeRepository employeeRepository,
            IAccessGridRepository accessGridRepository,
            ILogger<AccessGroupService> logger,
            AccessGroupValidator accessGroupValidator
            )
        {
            _accessGroupRepository = accessGroupRepository
                ?? throw new ArgumentNullException(nameof(accessGroupRepository));
            _employeeRepository = employeeRepository
                ?? throw new ArgumentNullException(nameof(employeeRepository));
            _accessGridRepository = accessGridRepository
                ?? throw new ArgumentNullException(nameof(accessGridRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _accessGroupValidator = accessGroupValidator
                ?? throw new ArgumentNullException(nameof(accessGroupValidator));
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
                var group = await _accessGroupRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), id);

                await _accessGroupRepository.DeleteAsync(group, cancellationToken);
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

        public async Task<AccessGroupDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessGroupRepository.GetByIdAsync(id, cancellationToken);
                return _mapper.Map<AccessGroupDto>(repRes);
            }, nameof(GetByIdAsync));
        }

        public async Task UpdateAsync(UpdateGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var repReq = await _accessGroupRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.Id);

                _mapper.Map(request, repReq);
                await _accessGroupRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }
        #endregion

        public async Task AddEmployeeToGroupAsync(AddEmployeeToGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(request.AccessGroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.AccessGroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                await _accessGridRepository.AddAsync(new AccessGrid
                {
                    EmployeeId = request.EmployeeId,
                    AccessGroupId = request.AccessGroupId,
                    IsActive = true
                }, cancellationToken);
            }, nameof(AddEmployeeToGroupAsync));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesInGroupAsync(int groupId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(groupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), groupId);

                var repRes = await _accessGridRepository.GetByAccessGroupIdAsync(groupId, cancellationToken);

                var employees = new List<EmployeeDto>();
                foreach (var accessGrid in repRes)
                {
                    var employee = await _employeeRepository.GetByIdAsync(accessGrid.EmployeeId, cancellationToken);
                    employees.Add(_mapper.Map<EmployeeDto>(employee));
                }

                return employees;
            }, nameof(GetEmployeesInGroupAsync));
        }

        public async Task RemoveEmployeeFromGroupAsync(RemoveEmployeeFromGroupReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _accessGroupRepository.ExistsAsync(request.AccessGroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.AccessGroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                var accessGrid = await _accessGridRepository.GetByIdAsync(request.EmployeeId, request.AccessGroupId, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessGrid), $"{nameof(AccessGrid.EmployeeId)}, {nameof(AccessGrid.AccessGroupId)}", $"{request.EmployeeId}, {request.AccessGroupId}");
                
                await _accessGridRepository.DeleteAsync(accessGrid, cancellationToken);
            }, nameof(RemoveEmployeeFromGroupAsync));
        }

        public async Task<IEnumerable<AccessGroupDto>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                if (!await _employeeRepository.ExistsAsync(employeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), employeeId);

                var repRes = (await _accessGridRepository.GetByEmployeeIdAsync(employeeId, cancellationToken));

                var response = repRes.Select(g => _mapper.Map<AccessGroupDto>(g.AccessGroup));

                return response;
            }, nameof(GetByEmployeeIdAsync));
        }
    }
}