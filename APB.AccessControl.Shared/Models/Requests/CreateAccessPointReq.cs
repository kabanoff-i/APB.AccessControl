using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CreateAccessPointReq
    {
        public string Name { get; set; }
        public int AccessPointTypeId { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
    }
}
