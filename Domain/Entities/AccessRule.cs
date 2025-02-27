using Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class AccessRule: BaseEntity
    {
        public int Id { get; set; }
        public int AccessGroupId { get; set; }
        public int AccessPointId { get; set; }
        public TimeSpan AllowedTimeStart { get; set; }
        public TimeSpan AllowedTimeEnd { get; set; }
        public int DaysOfWeek { get; set; }
        public string SpecificDates { get; set; }

        public AccessGroup AccessGroup { get; set; }
        public AccessPoint AccessPoint { get; set; }
    }
}
