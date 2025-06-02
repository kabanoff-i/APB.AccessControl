namespace APB.AccessControl.Shared.Models.Identity
{
    public class ChangePasswordReq
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
} 