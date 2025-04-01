using System;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Collections.Generic;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с уведомлениями
    /// </summary>
    public interface INotificationService: IService<CreateNotificationReq, UpdateNotificationReq, int, NotificationDto>
    {
        Task<IEnumerable<NotificationDto>> GetNotificationsByAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default);
        Task<IEnumerable<NotificationDto>> GetNotificationsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
        Task ProcessNotificationAsync(int notificationId, CancellationToken cancellationToken = default);
    }
}