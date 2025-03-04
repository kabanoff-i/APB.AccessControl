using System;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessTriggerLog
    {
        public Guid Id { get; set; }
        public Guid AccessLogId { get; set; }
        public int TriggerId { get; set; }
        public DateTime ExecuteAt { get; set; }
        public bool ExecutionResult { get; set; }
        public string ErrorMessage { get; set; }

        public AccessLog AccessLog { get; set; }
        public Trigger Trigger { get; set; }
    }

}
