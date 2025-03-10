using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.Common;
using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class EmployeeFilter: BaseFilter<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public byte[] Photo { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public override Expression<Func<Employee, bool>> GetExpression()
        {
            return p =>
                ((string.IsNullOrEmpty(FirstName) || p.FirstName.Contains(FirstName)) &&
                (string.IsNullOrEmpty(LastName) || p.FirstName.Contains(LastName)) &&
                (string.IsNullOrEmpty(PatronymicName) || p.FirstName.Contains(PatronymicName)) &&
                (string.IsNullOrEmpty(Department) || p.FirstName.Contains(Department)) &&
                (string.IsNullOrEmpty(Position) || p.FirstName.Contains(Position)) &&
                IsActive == p.IsActive
                );
        }
    }
}
