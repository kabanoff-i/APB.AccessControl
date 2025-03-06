using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Shared.Models.DTOs;
using System.Linq.Expressions;
using APB.AccessControl.Domain.Entities;
using System;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Expression<Func<EmployeeDto, bool>> filter, CancellationToken cancellationToken = default);
        Task CreateEmployeeAsync(CreateEmployeeReq request, CancellationToken cancellationToken = default);
        Task UpdateEmployeeAsync(UpdateEmployeeReq request, CancellationToken cancellationToken = default);
        Task DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
