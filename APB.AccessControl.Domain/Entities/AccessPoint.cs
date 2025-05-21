using APB.AccessControl.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessPoint: AuditedEntity
    {
        public int Id { get; set; }
        public int AccessPointTypeId { get; set; }
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastHeartbeatAt { get; set; }
        public bool IsOnline => LastHeartbeatAt.HasValue &&
                            DateTime.UtcNow - LastHeartbeatAt.Value < TimeSpan.FromMinutes(2);

        public AccessPointType AccessPointType { get; set; }
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AccessRule> AccessRules { get; set; } = new List<AccessRule>();
        public ICollection<Trigger> Triggers { get; set; } = new List<Trigger>();
    }

}
