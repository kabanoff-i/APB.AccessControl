using APB.AccessControl.Domain.Abstractions;
using APB.AccessControl.Domain.Primitives;
using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class Trigger: AuditedEntity
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public AccessResult AccessResult { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionValue { get; set; }
        public bool IsActive { get; set; }

        public AccessPoint AccessPoint { get; set; }
        public ActionType ActionType { get; set; }
        public ICollection<AccessTriggerLog> AccessLogTriggers { get; set; } = new List<AccessTriggerLog>();
    }

}
