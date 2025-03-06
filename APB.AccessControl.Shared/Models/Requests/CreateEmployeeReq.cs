namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateEmployeeReq
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public byte[] Photo { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
