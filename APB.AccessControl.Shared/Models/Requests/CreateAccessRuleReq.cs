using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessRuleReq
    {
        public int AccessGroupId { get; set; }
        public int AccessPointId { get; set; }
        public TimeSpan AllowedTimeStart { get; set; }
        public TimeSpan AllowedTimeEnd { get; set; }
        public BitArray DaysOfWeek {  get; set; }
        public string SpecificDates { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
