using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessTriggerLogRepository : IRepository<AccessTriggerLog, Guid>
    {
        Task<IEnumerable<AccessTriggerLog>> GetByAccessLogAsync(int accessLogId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessTriggerLog>> GetByFilterAsync(IFilter<AccessTriggerLog> filter, CancellationToken cancellationToken = default);
    }
}
