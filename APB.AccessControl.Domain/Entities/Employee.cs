using APB.AccessControl.Domain.Abstractions;
using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class Employee: AuditedEntity
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string PassportNumber { get; set; }
        public byte[] Photo { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AccessGrid> AccessGrids { get; set; } = new List<AccessGrid>();
    }

}
