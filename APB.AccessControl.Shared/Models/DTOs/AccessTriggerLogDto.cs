using System;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessTriggerLogDto
    {
        public Guid Id { get; set; }
        public Guid AccessLogId { get; set; }
        public int TriggerId { get; set; }
        public DateTime ExecuteAt { get; set; }
        public bool ExecutionResult { get; set; }
        public string ErrorMessage { get; set; }
    }
}