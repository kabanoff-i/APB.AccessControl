using APB.AccessControl.Domain.Abstractions;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessGrid: AuditedEntity
    {
        public int EmployeeId { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
        public AccessGroup AccessGroup { get; set; }
    }

}
