using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessPointTypeDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("��������")]
        public string Name { get; set; }
    }
} 