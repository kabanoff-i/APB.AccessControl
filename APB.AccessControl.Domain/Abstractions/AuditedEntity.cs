using System;

namespace APB.AccessControl.Domain.Abstractions
{
    public abstract class AuditedEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
