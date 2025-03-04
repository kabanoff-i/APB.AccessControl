using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee, int>
    {
        Task<Employee> GetByCardHashAsync(string cardHash, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetByAccessGroupAsync(int accessGroupId, CancellationToken cancellationToken = default);
    }
}
