using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Common;
using AutoMapper;
using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class AccessLogFilter: IFilter<AccessLog>
    {
        public int? CardId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AccessPointId { get; set; }
        public DateTime? AccessTimeStart { get; set; }
        public DateTime? AccessTimeEnd { get; set; }
        public AccessResult? AccessResult { get; set; }
        
        public Expression<Func<AccessLog, bool>> GetExpression()
        {
            return p =>
                ((CardId == null || p.CardId == CardId) &&
                 (EmployeeId == null || p.EmployeeId == EmployeeId) &&
                 (AccessPointId == null || p.AccessPointId == AccessPointId) &&
                 (AccessResult == null || p.AccessResult == AccessResult) &&
                 (AccessTimeStart == null || (p.DateAccess.ToUniversalTime() >= AccessTimeStart && p.DateAccess.ToUniversalTime() <= AccessTimeEnd))
                );
        }
    }
}
