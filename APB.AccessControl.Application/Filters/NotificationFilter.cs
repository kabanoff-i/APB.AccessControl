using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.Common;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class NotificationFilter: BaseFilter<Notification>
    {
        public int? EmployeeId { get; set; }
        public int? AccessPointId { get; set; }
        public bool? IsRead { get; set; }
        public bool? Expired { get; set; }

        public override Expression<Func<Notification, bool>> GetExpression()
        {
            return p =>
                (EmployeeId == null || p.EmployeeId == EmployeeId) &&
                (AccessPointId == null || p.AccessPointId == AccessPointId) &&
                (IsRead == null || p.IsRead == IsRead) &&
                (Expired == null || 
                    (Expired == true && (p.ExpirationDate != null && p.ExpirationDate < DateTime.Now)) ||
                    (Expired == false && (p.ExpirationDate == null || p.ExpirationDate >= DateTime.Now)));
        }
    }
}
