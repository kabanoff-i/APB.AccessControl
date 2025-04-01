using System;
using System.Collections;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateAccessRuleReq
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
