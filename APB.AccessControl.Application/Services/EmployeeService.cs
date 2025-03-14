using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Threading;
using System.Linq.Expressions;
using System;
using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using System.Net.Http.Headers;
using System.Data;
using APB.AccessControl.Domain.Exceptions;

namespace APB.AccessControl.Application.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public async Task<EmployeeDto> CreateAsync(CreateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var repReq = _mapper.Map<Employee>(request);
                Employee repResponce = await _employeeRepository.AddAsync(repReq);

                var response = _mapper.Map<EmployeeDto>(repResponce);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(UpdateEmployeeReq request, CancellationToken cancellationToken = default)
        {
            try {    
                //check if already exists
                if (!await _employeeRepository.ExistsAsync(request.Id))
                    throw new NotFoundException();

                var repReq = _mapper.Map<Employee>(request);
                await _employeeRepository.UpdateAsync(repReq);
            }
            catch {
                throw;
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                //check for already existing
                if (!await _employeeRepository.ExistsAsync(id))
                    throw new NotFoundException();

                var repReq = _mapper.Map<Employee>(id);
                await _employeeRepository.UpdateAsync(repReq);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _employeeRepository.GetAllAsync();
                var response = _mapper.Map<IEnumerable<EmployeeDto>>(repResponse);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _employeeRepository.GetByIdAsync(employeeId);
                if (repResponse == null)
                {
                    throw new NotFoundException();
                }
                var response = _mapper.Map<EmployeeDto>(repResponse);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByFilterAsync(EmployeeFilter employeeFilter = default, CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _employeeRepository.GetByFilterAsync(employeeFilter);
                var response = _mapper.Map<IEnumerable<EmployeeDto>>(repResponse);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetEmployeeByCardIdAsync(int cardId, CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _employeeRepository.GetByCardIdAsync(cardId);
                if(repResponse == null)
                    { throw new NotFoundException(); }

                var response = _mapper.Map<EmployeeDto>(repResponse);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CardDto>> GetCardsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _employeeRepository.GetByIdAsync(employeeId);
                if (repResponse == null)
                    { throw new NotFoundException(); }

                var cards = _mapper.Map<IEnumerable<CardDto>>(repResponse.Cards);
                return cards;
            }
            catch {
                throw;
            }
        }
    }
}
