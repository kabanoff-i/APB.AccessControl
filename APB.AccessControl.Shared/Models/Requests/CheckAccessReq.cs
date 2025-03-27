using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class CheckAccessReq
    {
        public string CardHash {  get; set; }
        public int AcсessPointId { get; set; }
        public DateTime DateAccess { get; set; }
    }
}
