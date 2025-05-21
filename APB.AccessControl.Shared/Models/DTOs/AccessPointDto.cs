using System;
using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessPointDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID типа точки доступа")]
        public int AccessPointTypeId { get; set; }
        [DisplayName("Тип точки доступа")]
        public string AccessPointTypeName { get; set; }
        [DisplayName("IP-адрес")]
        public string IpAddress { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Локация")]
        public string Location { get; set; }
        [DisplayName("Активна")]
        public bool IsActive { get; set; }
        [DisplayName("Последний heartbeat")]
        public DateTime? LastHeartbeatAt { get; set; }
        [DisplayName("Онлайн")]
        public bool IsOnline { get; set; } 
    }
}
