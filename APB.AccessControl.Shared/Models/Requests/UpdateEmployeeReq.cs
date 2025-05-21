using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateEmployeeReq
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Photo { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
    }
}
