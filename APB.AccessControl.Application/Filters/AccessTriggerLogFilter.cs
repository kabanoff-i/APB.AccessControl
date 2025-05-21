using System;
using System.Linq.Expressions;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.Common;

public class AccessTriggerLogFilter:BaseFilter<AccessTriggerLog>
{
        public Guid? AccessLogId { get; set; }
        public int? TriggerId { get; set; }
        public DateTime? ExecuteAtStart { get; set; }
        public DateTime? ExecuteAtEnd { get; set; }
        public bool? ExecutionResult { get; set; }


    public override Expression<Func<AccessTriggerLog, bool>> GetExpression()
    {
        return x =>
            (AccessLogId == null || x.AccessLogId == AccessLogId) &&
            (TriggerId == null || x.TriggerId == TriggerId) &&
            (ExecuteAtStart == null || x.ExecutedAt >= ExecuteAtStart) &&
            (ExecuteAtEnd == null || x.ExecutedAt <= ExecuteAtEnd) &&
            (ExecutionResult == null || x.ExecutionResult == ExecutionResult);
    }
}