using APB.AccessControl.Domain.Primitives;
using System;
using System.Collections.Generic;
using APB.AccessControl.Domain.Abstractions;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessLog: AuditedEntity
    {
        public Guid Id { get; set; }
        public int? CardId { get; set; }
        public string CardHash { get; set; }
        public int? EmployeeId { get; set; }
        public int AccessPointId { get; set; }
        public DateTime DateAccess { get; set; }
        public AccessResult AccessResult { get; set; }
        public string Message { get; set; }

        public Card Card { get; set; }
        public Employee Employee { get; set; }
        public AccessPoint AccessPoint { get; set; }
        public ICollection<AccessTriggerLog> AccessLogTriggers { get; set; } = new List<AccessTriggerLog>();
    }
}
