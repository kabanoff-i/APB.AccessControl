using System;
using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class NotificationDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID точки доступа")]
        public int AccessPointId { get; set; }
        [DisplayName("Название точки доступа")]
        public string AccessPointName { get; set; }
        [DisplayName("Показ при проходе")]
        public bool ShowOnPass { get; set; }
        [DisplayName("ID сотрудника")]
        public int? EmployeeId { get; set; }
        [DisplayName("ФИО сотрудника")]
        public string EmployeeFullName { get; set; }
        [DisplayName("Сообщение")]
        public string Message { get; set; }
        [DisplayName("Дата истечения")]
        public DateTime? ExpirationDate { get; set; }
        [DisplayName("Прочитано")]
        public bool IsRead { get; set; }
        [DisplayName("Дата последнего обновления")]
        public DateTime UpdatedAt { get; set; }
    }
}