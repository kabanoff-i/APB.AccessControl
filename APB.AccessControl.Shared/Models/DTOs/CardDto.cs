using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class CardDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Маска карты")]
        public string MaskPan { get; set; }
        [DisplayName("ID сотрудника")]
        public int EmployeeId { get; set; }
        [DisplayName("ФИО сотрудника")]
        public string EmployeeFullName { get; set; }
        [DisplayName("Активна")]
        public bool IsActive { get; set; }
    }
}
