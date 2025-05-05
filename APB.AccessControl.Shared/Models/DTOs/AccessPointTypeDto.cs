using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessPointTypeDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
} 