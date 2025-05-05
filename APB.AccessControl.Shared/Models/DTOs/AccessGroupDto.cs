using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessGroupDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public bool IsActive { get; set; }
    }
}
