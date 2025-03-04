using APB.AccessControl.Domain.Primitives;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessLog
    {
        public Guid Id { get; set; }
        public int CardId { get; set; }
        public int EmployeeId { get; set; }
        public int AccessPointId { get; set; }
        public DateTime AccessTime { get; set; }
        public AccessResult AccessResult { get; set; }

        public Card Card { get; set; }
        public Employee Employee { get; set; }
        public AccessPoint AccessPoint { get; set; }
        public ICollection<AccessTriggerLog> AccessLogTriggers { get; set; } = new List<AccessTriggerLog>();
    }
}
