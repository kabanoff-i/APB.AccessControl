namespace APB.AccessControl.Shared.Models.Requests
{
    public class RemoveEmployeeFromGroupReq
    {
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
    }
}
