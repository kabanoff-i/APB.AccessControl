using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions
{
    public abstract class BaseEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
