using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessLogRepository : IRepository<AccessLog, Guid>
    {
        Task<IEnumerable<AccessLog>> GetLogsAsync(Expression<Func<AccessLog, bool>> filter = null, CancellationToken cancellationToken = default);
    }

}
