using System;

namespace APB.AccessControl.Domain.Abstractions
{
    public abstract class AuditedEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
