using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Identity
{
    public class CreateUserReq
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
