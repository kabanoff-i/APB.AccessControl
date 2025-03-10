using System;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessLogDto
    {
        public Guid Id { get; set; }
        public int CardId { get; set; }
        public int EmployeeId { get; set; }
        public int AccessPointId { get; set; }
        public DateTime AccessTime { get; set; }
        public int AccessResult { get; set; }
    }
}