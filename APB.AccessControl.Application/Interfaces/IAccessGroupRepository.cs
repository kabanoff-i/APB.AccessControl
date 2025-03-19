using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessGroupRepository : IRepository<AccessGroup, int>
    {
        Task<IEnumerable<AccessRule>> GetAccessRulesByGroupIdAsync(int groupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int groupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessGroup>> GetGroupsByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
        Task AssignEmployeeToGroupAsync(int employeeId, int groupId, CancellationToken cancellationToken = default);
        Task RemoveEmployeeFromGroupAsync(int employeeId, int groupId, CancellationToken cancellationToken = default);

    }
}
