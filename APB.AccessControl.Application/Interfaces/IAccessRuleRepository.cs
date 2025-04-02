using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessRuleRepository : IRepository<AccessRule, int>
    {
        Task<IEnumerable<AccessRule>> GetByFilterAsync(IFilter<AccessRule> filter, CancellationToken cancellationToken = default);
    }
}
