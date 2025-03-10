using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Requests
{
    public class UpdateCardReq
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
