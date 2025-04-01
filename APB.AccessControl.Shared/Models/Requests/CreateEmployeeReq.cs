namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateEmployeeReq
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string PassportNumber { get; set; }
        public string Photo { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
