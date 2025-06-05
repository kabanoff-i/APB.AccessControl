using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Responses
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string ErrorMessage { get; set; }
        public UserDto User { get; set; }
    }
}
