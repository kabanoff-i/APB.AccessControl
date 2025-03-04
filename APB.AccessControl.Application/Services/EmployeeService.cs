using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using AutoMapper;
using APB.AccessControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<Employee> Add(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Delete(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Get(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
