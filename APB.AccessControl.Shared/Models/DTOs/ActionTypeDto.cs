using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class ActionTypeDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("��������")]
        public string Name { get; set; }
    }
} 