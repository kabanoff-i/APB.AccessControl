using System;
using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessLogDto
    {
        [DisplayName("ID")]
        public Guid Id { get; set; }
        [DisplayName("ID карты")]
        public int CardId { get; set; }
        [DisplayName("Маска карты")]
        public string MaskPan { get; set; }
        [DisplayName("ID сотрудника")]
        public int EmployeeId { get; set; }
        [DisplayName("ФИО сотрудника")]
        public string EmployeeFullName { get; set; }
        [DisplayName("ID точки доступа")]
        public int AccessPointId { get; set; }
        [DisplayName("Название точки доступа")]
        public string AccessPointName { get; set; }
        [DisplayName("Дата попытки прохода")]
        public DateTime DateAccess { get; set; }
        [DisplayName("Результат попытки прохода")]
        public int AccessResult { get; set; }
        [DisplayName("Информация")]
        public string Message { get; set; }
    }
}