namespace APB.AccessControl.Shared.Models.DTOs
{
    public class TriggerDto
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public int AccessResult { get; set; }
        public int ActionType { get; set; }
        public string ActionValue { get; set; }
        public bool IsActive { get; set; }
    }
}