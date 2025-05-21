namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateTriggerReq
    {
        public string Name { get; set; }
        public int AccessPointId { get; set; }
        public int AccessResult { get; set; }
        public int ActionType { get; set; }
        public string ActionValue { get; set; }
    }
}