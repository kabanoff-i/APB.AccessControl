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

namespace APB.AccessControl.Application.Services
{
    public class AccessGroupService: IAccessGroupService
    {
        private readonly IAccessGroupRepository _accessGroupRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public AccessGroupService(IAccessGroupRepository accessGroupRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _accessGroupRepository = accessGroupRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        #region CRUD

        public async Task<AccessGroupDto> CreateAsync(CreateGroupReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var repReq = _mapper.Map<AccessGroup>(request);

                var repRes = await _accessGroupRepository.AddAsync(repReq, cancellationToken);
                var response = _mapper.Map<AccessGroupDto>(repRes);

                return response;

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
                //check for already existing
                if (!await _accessGroupRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), id);

                await _accessGroupRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AccessGroupDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _accessGroupRepository.GetAllAsync(cancellationToken);
                var response = _mapper.Map<IEnumerable<AccessGroupDto>>(repRes);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        

        public async Task UpdateAsync(UpdateGroupReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _accessGroupRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.Id);

                var repReq = _mapper.Map<AccessGroup>(request);
                await _.UpdateAsync(repReq, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
#endregion

        public async Task AddEmployeeToGroupAsync(AddEmployeeToGroupReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _accessGroupRepository.ExistsAsync(request.GroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.GroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                await _accessGroupRepository.AssignEmployeeToGroupAsync(request.EmployeeId, request.GroupId, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesInGroupAsync(int groupId, CancellationToken cancellationToken = default)
        {
            try
            {
                //check for already existing
                if (!await _accessGroupRepository.ExistsAsync(groupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), groupId);

                var repRes = await _accessGroupRepository.GetEmployeesByGroupIdAsync(groupId, cancellationToken);
                var response = _mapper.Map<IEnumerable<EmployeeDto>>(repRes);

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task RemoveEmployeeFromGroupAsync(RemoveEmployeeFromGroupReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _accessGroupRepository.ExistsAsync(request.GroupId, cancellationToken))
                    throw new NotFoundException(nameof(AccessGroup), nameof(AccessGroup.Id), request.GroupId);

                if (!await _employeeRepository.ExistsAsync(request.EmployeeId, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), request.EmployeeId);

                await _accessGroupRepository.RemoveEmployeeFromGroupAsync(request.EmployeeId, request.GroupId, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
