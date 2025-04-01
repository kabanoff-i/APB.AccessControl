using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessLogReq
    {
        public int? CardId { get; set; }
        public string CardHash { get; set; }
        public int? EmployeeId { get; set; }
        public int AccessPointId { get; set; }
        public DateTime DateAccess { get; set; }
        public int AccessResult { get; set; }
        public string Message { get; set; }
    }
}