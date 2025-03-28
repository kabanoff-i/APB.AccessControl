using System;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с уведомлениями
    /// </summary>
    public interface INotificationService: IService<CreateNotificationReq, UpdateNotificationReq, Guid, NotificationDto>
    {
        Task ReadNotificationAsync(Guid id, CancellationToken cancellationToken = default);
        Task CheckActiveNotificationsAsync(int accessPointId, int employeeId, CancellationToken cancellationToken = default);
    }
}