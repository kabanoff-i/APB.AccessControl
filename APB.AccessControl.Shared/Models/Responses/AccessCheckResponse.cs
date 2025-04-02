using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.Shared.Models.Responses
{
    public class AccessCheckResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
