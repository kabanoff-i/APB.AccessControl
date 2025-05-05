using APB.AccessControl.Domain.Abstractions;
using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class Card: AuditedEntity
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string MaskPan { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
    }
}
