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
        Task<IEnumerable<Employee>> GetEmployeesInGroupAsync(int groupId, CancellationToken cancellationToken = default);
        Task AddEmployeeToGroupAsync(AccessGrid accessGrid, CancellationToken cancellationToken = default);

    }
}
