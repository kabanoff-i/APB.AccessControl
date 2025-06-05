using System;

namespace APB.AccessControl.Shared.Models.DTOs
{
    public class QueuedAccessCheckDto
    {
        public string CardNumber { get; set; }
        public int AccessPointId { get; set; }
        public DateTime CheckTime { get; set; }
        public bool IsProcessed { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }
} 