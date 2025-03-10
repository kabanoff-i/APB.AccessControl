namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateTriggerReq
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public int AccessResult { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionValue { get; set; }
        public bool IsActive { get; set; }
    }
}