using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.Common;
using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Filters
{
    public class EmployeeFilter: IFilter<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string PassportNumber { get; set; }
        public bool IsActive { get; set; }

        public Expression<Func<Employee, bool>> GetExpression()
        {
            return p =>
                ((string.IsNullOrEmpty(FirstName) || p.FirstName.Contains(FirstName)) &&
                (string.IsNullOrEmpty(LastName) || p.FirstName.Contains(LastName)) &&
                (string.IsNullOrEmpty(PatronymicName) || p.FirstName.Contains(PatronymicName)) &&
                (string.IsNullOrEmpty(Department) || p.FirstName.Contains(Department)) &&
                (string.IsNullOrEmpty(Position) || p.FirstName.Contains(Position)) &&
                (string.IsNullOrEmpty(PassportNumber) || p.PassportNumber.Contains(PassportNumber)) &&
                IsActive == p.IsActive
                );
        }
    }
}
