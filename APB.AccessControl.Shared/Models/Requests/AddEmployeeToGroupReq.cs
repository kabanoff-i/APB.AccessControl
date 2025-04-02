namespace APB.AccessControl.Shared.Models.Requests
{
    public class AddEmployeeToGroupReq
    {
        public int EmployeeId { get; set; }
        public int AccessGroupId { get; set; }
    }
}
