using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Domain.Entities;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessTriggerLogRepository : IRepository<AccessTriggerLog, Guid>
    {
        Task<IEnumerable<AccessTriggerLog>> GetByAccessLogAsync(int accessLogId, CancellationToken cancellationToken = default);
    }
}
