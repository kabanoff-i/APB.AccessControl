using APB.AccessControl.Shared.Models.Common;
using System;

namespace APB.AccessControl.Shared.Models.Filters
{ 
    public class AccessTriggerLogFilterDto
    {
            public Guid? AccessLogId { get; set; }
            public int? TriggerId { get; set; }
            public DateTime? ExecuteAtStart { get; set; }
            public DateTime? ExecuteAtEnd { get; set; }
            public bool? ExecutionResult { get; set; }

    }
}