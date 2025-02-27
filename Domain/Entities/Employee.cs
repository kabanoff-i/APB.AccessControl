using Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee: BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string PhotoFilePath { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AccessGrid> AccessGrids { get; set; } = new List<AccessGrid>();
    }

}
