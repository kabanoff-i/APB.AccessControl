using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Identity
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
