using System;
using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class AccessTriggerLogDto
    {
        [DisplayName("ID")]
        public Guid Id { get; set; }
        [DisplayName("ID лога доступа")]
        public Guid AccessLogId { get; set; }
        [DisplayName("ID триггера")]
        public int TriggerId { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime ExecuteAt { get; set; }
        [DisplayName("Результат выполнения")]
        public bool ExecutionResult { get; set; }
        [DisplayName("Текст ошибки")]
        public string ErrorMessage { get; set; }
    }
}