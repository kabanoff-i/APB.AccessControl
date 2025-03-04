using System;

namespace APB.AccessControl.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
