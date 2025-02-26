using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Card
    {
        public string Id { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime IssuedAt { get; set; }

        public Employee Employee { get; set; }
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
    }
}
