using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using System.Linq;

namespace APB.AccessControl.Application.Services
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            INotificationRepository notificationRepository, 
            IMapper mapper,
            ILogger<NotificationService> logger)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NotificationDto> CreateAsync(CreateNotificationReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<Notification>(request);
                var repRes = await _notificationRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<NotificationDto>(repRes);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _notificationRepository.ExistsAsync(id, cancellationToken))
                    throw new NotFoundException(nameof(Notification), nameof(Notification.Id), id);

                await _notificationRepository.DeleteAsync(id, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _notificationRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<NotificationDto>>(repRes);
            }, nameof(GetAllAsync));
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsByAccessPointAsync(int accessPointId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var notifications = await _notificationRepository.GetActiveNotificationsByAccessPointAsync(accessPointId, cancellationToken);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }, nameof(GetNotificationsByAccessPointAsync));
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var notifications = await _notificationRepository.GetActiveNotificationsByEmployeeAsync(employeeId, cancellationToken);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }, nameof(GetNotificationsByEmployeeAsync));
        }

        public async Task ProcessNotificationAsync(Guid notificationId, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var notification = await _notificationRepository.GetByIdAsync(notificationId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Notification), nameof(Notification.Id), notificationId);

                notification.IsRead = true;
                await _notificationRepository.UpdateAsync(notification, cancellationToken);
            }, nameof(ProcessNotificationAsync));
        }

        public async Task UpdateAsync(UpdateNotificationReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                if (!await _notificationRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(Notification), nameof(Notification.Id), request.Id);

                var repReq = _mapper.Map<Notification>(request);
                await _notificationRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }

       
    }
}
