namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateCardReq
    {
        public int EmployeeId { get; set; }
        public string Hash { get; set; }
        public string MaskPan { get; set; }
    }
}
