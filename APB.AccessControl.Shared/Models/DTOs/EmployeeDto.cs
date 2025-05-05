using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class EmployeeDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string PatronymicName { get; set; }
        [DisplayName("Номер паспорта")]
        public string PassportNumber { get; set; }
        [DisplayName("Фото")]
        public string Photo { get; set; }
        [DisplayName("Отдел")]
        public string Department { get; set; }
        [DisplayName("Должность")]
        public string Position { get; set; }
        [DisplayName("Активен")]
        public bool IsActive { get; set; }

    }
}
