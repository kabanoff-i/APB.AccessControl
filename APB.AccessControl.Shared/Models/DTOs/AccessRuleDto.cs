using System.Collections;
using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessRuleDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID группы доступа")]
        public int AccessGroupId { get; set; }
        [DisplayName("Название группы доступа")]
        public string AccessGroupName { get; set; }
        [DisplayName("ID точки доступа")]
        public int AccessPointId { get; set; }
        [DisplayName("Название точки доступа")]
        public string AccessPointName { get; set; }
        [DisplayName("Время начала")]
        public TimeSpan AllowedTimeStart { get; set; }
        [DisplayName("Время окончания")]
        public TimeSpan AllowedTimeEnd { get; set; }
        [DisplayName("Дни недели")]
        public bool[] DaysOfWeek { get; set; }
        [DisplayName("Специальные даты")]
        public string SpecificDates { get; set; }
        [DisplayName("Дата начала")]
        public DateTime StartDate { get; set; }
        [DisplayName("Дата окончания")]
        public DateTime EndDate { get; set; }
        [DisplayName("Активно")]
        public bool IsActive { get; set; }
    }
}
