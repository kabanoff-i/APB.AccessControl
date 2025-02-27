using Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class Notification: BaseEntity
    {
        public Guid Id { get; set; }
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
