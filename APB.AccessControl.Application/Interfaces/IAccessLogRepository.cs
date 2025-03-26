using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;
using APB.AccessControl.Application.Filters;
using System.Security.Cryptography;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessLogRepository
    {
        Task<AccessLog> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessLog>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AccessLog> AddAsync(AccessLog entity, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessLog>> GetLogsByFilterAsync(AccessLogFilter filter, CancellationToken cancellationToken = default);
    }
}
