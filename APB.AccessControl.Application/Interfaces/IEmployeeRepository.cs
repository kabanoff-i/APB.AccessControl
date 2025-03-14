using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee, int>
    {
        Task<Employee> GetByCardIdAsync(int cardId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetByAccessGroupAsync(int accessGroupId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetByFilterAsync(IFilter<Employee> filter, CancellationToken cancellationToken = default);

    }
}
