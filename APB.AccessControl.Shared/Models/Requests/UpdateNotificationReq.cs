using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateNotificationReq
    {
        public int Id { get; set; }
        public int AccessPointId { get; set; }
        public bool ShowOnPass { get; set; }
        public int? EmployeeId { get; set; }
        public string Message { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}