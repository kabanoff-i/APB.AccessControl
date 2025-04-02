using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с группами доступа
    /// </summary>
    public interface IAccessGroupService: IService<CreateGroupReq, UpdateGroupReq, int, AccessGroupDto>
    {
        Task AddEmployeeToGroupAsync(AddEmployeeToGroupReq request, CancellationToken cancellationToken = default);
        Task RemoveEmployeeFromGroupAsync(RemoveEmployeeFromGroupReq request, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetEmployeesInGroupAsync(int groupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessGroupDto>> GetByEmployeeIdAsync(int employeeId,  CancellationToken cancellationToken = default);
    }
}