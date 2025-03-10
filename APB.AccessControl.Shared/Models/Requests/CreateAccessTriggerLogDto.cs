using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessTriggerLogDto
    {
        public Guid Id { get; set; }
        public Guid AccessLogId { get; set; }
        public int TriggerId { get; set; }
        public DateTime ExecuteAt { get; set; }
        public bool ExecutionResult { get; set; }
        public string ErrorMessage { get; set; }
    }
}