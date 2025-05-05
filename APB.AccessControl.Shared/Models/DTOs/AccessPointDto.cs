using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessPointDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID типа точки доступа")]
        public int AccessPointTypeId { get; set; }
        [DisplayName("IP-адрес")]
        public string IpAddress { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Локация")]
        public string Location { get; set; }
        [DisplayName("Активна")]
        public bool IsActive { get; set; }
    }
}
