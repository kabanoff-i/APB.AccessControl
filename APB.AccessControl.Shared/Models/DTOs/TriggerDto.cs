using System.ComponentModel;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class TriggerDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID точки доступа")]
        public int AccessPointId { get; set; }
        [DisplayName("Результат события")]
        public int AccessResult { get; set; }
        [DisplayName("Тип действия")]
        public int ActionType { get; set; }
        [DisplayName("Строка к выполнению")]
        public string ActionValue { get; set; }
        [DisplayName("Активен")]
        public bool IsActive { get; set; }
    }
}