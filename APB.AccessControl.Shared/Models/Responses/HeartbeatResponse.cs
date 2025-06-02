using System.Collections.Generic;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.Shared.Models.Responses
{
    public class HeartbeatResponse
    {
        public bool Success { get; set; }
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
    }
} 