namespace APB.AccessControl.Application.Filters
{
    public class NotificationFilterDto
    {
        public int? EmployeeId { get; set; }
        public int? AccessPointId { get; set; }
        public bool? IsRead { get; set; }
        public bool? Expired { get; set; }
    }
}
