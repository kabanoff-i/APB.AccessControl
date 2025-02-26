using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Trigger
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public int AccessResult { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionValue { get; set; }
        public bool IsActive { get; set; }

        public AccessPoint AccessPoint { get; set; }
        public ActionType ActionType { get; set; }
        public ICollection<AccessTriggerLog> AccessLogTriggers { get; set; }

        public Trigger()
        {
            AccessLogTriggers = new List<AccessTriggerLog>();
        }
    }

}
