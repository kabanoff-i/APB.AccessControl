using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace APB.AccessControl.Shared.Models.Responses
{
    public class AccessCheckResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int? EmployeeId { get; set; }
        public int? CardId { get; set; }
        
        // Информация о сотруднике для верификации
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Photo { get; set; }
    }
}
