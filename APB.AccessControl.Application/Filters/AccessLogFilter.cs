using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Common;
using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class AccessLogFilter: BaseFilter<AccessLog>
    {
        public int? CardId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AccessPointId { get; set; }
        public DateTime? AccessTimeStart { get; set; }
        public DateTime? AccessTimeEnd { get; set; } = DateTime.UtcNow;
        public AccessResult? AccessResult { get; set; }

        public override Expression<Func<AccessLog, bool>> GetExpression()
        {
            return p =>
                ((CardId == null || p.CardId == CardId) &&
                 (EmployeeId == null || p.EmployeeId == EmployeeId) &&
                 (AccessPointId == null || p.AccessPointId == AccessPointId) &&
                 (AccessResult == null || p.AccessResult == AccessResult) &&
                 (AccessTimeStart == null || (p.DateAccess >= AccessTimeStart && p.DateAccess <= AccessTimeEnd))
                );
        }
    }
}
