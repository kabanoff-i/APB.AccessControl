using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class ActionTypeDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
} 