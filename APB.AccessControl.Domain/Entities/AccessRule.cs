using APB.AccessControl.Domain.Abstractions;
using System;
using System.Collections;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessRule: AuditedEntity
    {
        public int Id { get; set; }
        public int AccessGroupId { get; set; }
        public int AccessPointId { get; set; }
        public TimeSpan AllowedTimeStart { get; set; }
        public TimeSpan AllowedTimeEnd { get; set; }
        public BitArray DaysOfWeek { get; set; }
        public string SpecificDates { get; set; }

        public AccessGroup AccessGroup { get; set; }
        public AccessPoint AccessPoint { get; set; }
    }
}
