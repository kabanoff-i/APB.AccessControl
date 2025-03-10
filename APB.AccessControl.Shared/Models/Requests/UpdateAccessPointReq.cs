namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateAccessPointReq
    {
        public int Id { get; set; }
        public int AccessPointTypeId { get; set; }
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
    }
}
