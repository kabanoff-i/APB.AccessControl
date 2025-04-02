using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Common;
using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class AccessRuleFilter: BaseFilter<AccessRule>
    {
        public int? AccessGroupId { get; set; }
        public int? AccessPointId { get; set; }

        public override Expression<Func<AccessRule, bool>> GetExpression()
        {
            return p =>(
                (AccessGroupId == null || p.AccessGroupId == AccessGroupId) &&
                (AccessPointId == null || p.AccessPointId == AccessPointId)
            );
        }
    }
}
