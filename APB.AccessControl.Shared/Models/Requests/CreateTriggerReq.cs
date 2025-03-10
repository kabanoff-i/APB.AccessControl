namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateTriggerReq
    {
        public int AccessPointId { get; set; }
        public int AccessResult { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionValue { get; set; }
    }
}