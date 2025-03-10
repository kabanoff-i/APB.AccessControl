using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessRuleRepository : IRepository<AccessRuleDto, int>
    {
        Task<IEnumerable<AccessRuleDto>> GetRulesForGroupAsync(int groupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessRuleDto>> GetRulesForAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default);
    }
}
