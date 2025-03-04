using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface INotificationRepository: IRepository<Notification, Guid>
    {
        Task<IEnumerable<Notification>> GetActiveNotificationsByAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Notification>> GetActiveNotificationsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
