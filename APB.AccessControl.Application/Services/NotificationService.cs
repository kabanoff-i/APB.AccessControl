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

namespace APB.AccessControl.Application.Services
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper) 
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<NotificationDto> CreateAsync(CreateNotificationReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                var repReq = _mapper.Map<Notification>(request);
                var repResponse = await _notificationRepository.AddAsync(repReq)
                    ?? throw new ConflictException();

                var response = _mapper.Map<NotificationDto>(repResponse);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!await _notificationRepository.ExistsAsync(id))
                    throw new NotFoundException(nameof(Notification), nameof(Notification.Id), id);

                await _notificationRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var repRes = await _notificationRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<NotificationDto>>(repRes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ReadNotificationAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var repResponse = await _notificationRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException(nameof(Notification), nameof(Notification.Id), id);

                repResponse.IsRead = true;

                await _notificationRepository.UpdateAsync(repResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(UpdateNotificationReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                //check if already exists
                if (!await _notificationRepository.ExistsAsync(request.Id, cancellationToken))
                    throw new NotFoundException(nameof(Notification), nameof(Notification.Id), request.Id);

                var repReq = _mapper.Map<Notification>(request);
                await _notificationRepository.UpdateAsync(repReq, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CheckActiveNotificationsAsync(int accessPointId, int employeeId, CancellationToken cancellationToken = default)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
