using APB.AccessControl.Domain.Abstractions;
using System;

namespace APB.AccessControl.Domain.Entities
{
    public class Notification: AuditedEntity
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public bool ShowOnPass { get; set; }
        public int? EmployeeId { get; set; }
        public string Message { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsRead { get; set; }

        public Employee Employee { get; set; }
        public AccessPoint AccessPoint { get; set; }
    }
}
