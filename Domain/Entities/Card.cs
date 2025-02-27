using Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Card: BaseEntity
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
    }
}
