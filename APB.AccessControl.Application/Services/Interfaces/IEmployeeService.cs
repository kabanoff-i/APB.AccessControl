using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Application.Filters;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с сотрудниками
    /// </summary>
    public interface IEmployeeService: IService<CreateEmployeeReq, UpdateEmployeeReq, int, EmployeeDto>
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByFilterAsync(EmployeeFilter employeeFilter = default, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetEmployeeByCardIdAsync(int cardId, CancellationToken cancellationToken = default);
        Task<IEnumerable<CardDto>> GetCardsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
