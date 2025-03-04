using APB.AccessControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface ITriggerRepository : IRepository<Trigger, int>
    {
        Task<IEnumerable<Trigger>> GetTriggersForAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default);
    }
}
