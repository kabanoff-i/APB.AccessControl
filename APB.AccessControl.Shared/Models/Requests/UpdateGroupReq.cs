namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateGroupReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
