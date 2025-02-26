using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AccessGrid
    {
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Employee Employee { get; set; }
        public AccessGroup AccessGroup { get; set; }
    }

}
