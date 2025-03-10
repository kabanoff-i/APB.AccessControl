using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessLogReq
    {
        public int CardId { get; set; }
        public int EmployeeId { get; set; }
        public int AccessPointId { get; set; }
        public DateTime AccessTime { get; set; }
        public int AccessResult { get; set; }
    }
}
