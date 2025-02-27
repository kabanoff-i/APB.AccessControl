using Domain.Abstractions;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AccessPoint: BaseEntity
    {
        public int Id { get; set; }
        public int AccessPointTypeId { get; set; }
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }

        public AccessPointType AccessPointType { get; set; }
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AccessRule> AccessRules { get; set; } = new List<AccessRule>();
        public ICollection<Trigger> Triggers { get; set; } = new List<Trigger>();
    }

}
