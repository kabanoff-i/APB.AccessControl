using System.Collections;
using System;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessRuleDto
    {
        public int Id { get; set; }
        public int AccessGroupId { get; set; }
        public int AccessPointId { get; set; }
        public TimeSpan AllowedTimeStart { get; set; }
        public TimeSpan AllowedTimeEnd { get; set; }
        public BitArray DaysOfWeek { get; set; }
        public string SpecificDates { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}
