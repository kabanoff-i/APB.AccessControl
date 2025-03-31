using System;
using System.Linq.Expressions;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Common;

public class AccessTriggerLogFilter:BaseFilter<AccessTriggerLog>
{
        public Guid? AccessLogId { get; set; }
        public int? TriggerId { get; set; }
        public DateTime? ExecuteAt { get; set; }
        public bool? ExecutionResult { get; set; }


    public override Expression<Func<AccessTriggerLog, bool>> GetExpression()
    {
        return x =>
            (AccessLogId == null || x.AccessLogId == AccessLogId) &&
            (TriggerId == null || x.TriggerId == TriggerId) &&
            (ExecuteAt == null || x.ExecutedAt == ExecuteAt) &&
            (ExecutionResult == null || x.ExecutionResult == ExecutionResult);
    }
}