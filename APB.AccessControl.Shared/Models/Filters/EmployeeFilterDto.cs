namespace APB.AccessControl.Shared.Models.Filters
{
    public class EmployeeFilterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string PassportNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
