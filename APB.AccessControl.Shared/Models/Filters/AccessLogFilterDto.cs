using System;

namespace APB.AccessControl.Shared.Models.Filters
{
    public class AccessLogFilterDto
    {
        public int? CardId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AccessPointId { get; set; }
        public DateTime? AccessTimeStart { get; set; }
        public DateTime? AccessTimeEnd { get; set; } 
        public int? AccessResult { get; set; }
    }
}
