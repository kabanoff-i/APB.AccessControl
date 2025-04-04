using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.Application.Interfaces
{
    public interface INotificationRepository: IRepository<Notification, int>
    {
        Task<IEnumerable<Notification>> GetByFilter(IFilter<Notification> filter, CancellationToken cancellationToken = default);
    }
}
