using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;
using APB.AccessControl.Application.Filters;
using System.Security.Cryptography;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessLogRepository: IRepository<AccessLog, Guid>
    {
        Task<IEnumerable<AccessLog>> GetByFilterAsync(IFilter<AccessLog> filter, CancellationToken cancellationToken = default);
    }
}
