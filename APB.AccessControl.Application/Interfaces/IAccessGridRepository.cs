using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Domain.Entities;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessGridRepository
    {
        Task<IEnumerable<AccessGrid>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessGrid>> GetByAccessGroupIdAsync(int AccessGroupId, CancellationToken cancellationToken = default);
        Task<AccessGrid> GetByIdAsync(int employeeId, int accessGroupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessGrid>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AccessGrid> AddAsync(AccessGrid entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(AccessGrid entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(AccessGrid entity, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(int employeeId, int accessGroupId, CancellationToken cancellationToken = default);
    }
}