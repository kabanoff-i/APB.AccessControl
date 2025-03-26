using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessTriggerLogReq
    {
        public Guid AccessLogId { get; set; }
        public int TriggerId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public bool ExecutionResult { get; set; }
        public string ErrorMessage { get; set; }
    }
}