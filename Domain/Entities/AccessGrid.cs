using Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class AccessGrid: BaseEntity
    {
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
        public AccessGroup AccessGroup { get; set; }
    }

}
