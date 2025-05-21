using System;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class HeartbeatReq
    {
        public int AccessPointId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
} 