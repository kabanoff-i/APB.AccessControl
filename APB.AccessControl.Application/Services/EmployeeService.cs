using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Threading;
using System;
using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;

namespace APB.AccessControl.Application.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(
            IEmployeeRepository employeeRepository, 
            IMapper mapper,
            ILogger<EmployeeService> logger) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<Employee>(request);
                var repResponse = await _employeeRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<EmployeeDto>(repResponse);
            }, nameof(CreateAsync));
        }

        public async Task UpdateAsync(UpdateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _employeeRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(Employee));

                var repReq = _mapper.Map<Employee>(request);
                await _employeeRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _employeeRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(Employee), nameof(Employee.Id), id);

                await _employeeRepository.DeleteAsync(id, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _employeeRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<EmployeeDto>>(repResponse);
            }, nameof(GetAllAsync));
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Employee), nameof(Employee.Id), employeeId);

                return _mapper.Map<EmployeeDto>(repResponse);
            }, nameof(GetEmployeeByIdAsync));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByFilterAsync(EmployeeFilter employeeFilter = default, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _employeeRepository.GetByFilterAsync(employeeFilter, cancellationToken);
                return _mapper.Map<IEnumerable<EmployeeDto>>(repResponse);
            }, nameof(GetEmployeesByFilterAsync));
        }

        public async Task<EmployeeDto> GetEmployeeByCardIdAsync(int cardId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _employeeRepository.GetByCardIdAsync(cardId, cancellationToken)
                     ?? throw new NotFoundException(nameof(Employee), nameof(Card.Id), cardId);

                return _mapper.Map<EmployeeDto>(repResponse);
            }, nameof(GetEmployeeByCardIdAsync));
        }
    }
}
