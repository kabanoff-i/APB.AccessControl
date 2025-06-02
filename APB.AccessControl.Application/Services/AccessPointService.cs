using APB.AccessControl.Application.Interfaces;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using AutoMapper;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Application.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace APB.AccessControl.Application.Services
{
    public class AccessPointService : IAccessPointService
    {
        private readonly IAccessPointRepository _accessPointRepository;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessPointService> _logger;

        public AccessPointService(
            IAccessPointRepository accessPointRepository,
            INotificationService notificationService,
            IMapper mapper,
            ILogger<AccessPointService> logger)
        {
            _accessPointRepository = accessPointRepository
                ?? throw new ArgumentNullException(nameof(accessPointRepository));
            _notificationService = notificationService
                ?? throw new ArgumentNullException(nameof(notificationService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccessPointDto> CreateAsync(CreateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repReq = _mapper.Map<AccessPoint>(request);
                var repResponse = await _accessPointRepository.AddAsync(repReq, cancellationToken);
                return _mapper.Map<AccessPointDto>(repResponse);
            }, nameof(CreateAsync));
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var repRes = await _accessPointRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                await _accessPointRepository.DeleteAsync(repRes, cancellationToken);
            }, nameof(DeleteAsync));
        }

        public async Task<IEnumerable<AccessPointDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _accessPointRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<AccessPointDto>>(repResponse);
            }, nameof(GetAllAsync));
        }

        public async Task<AccessPointDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var repResponse = await _accessPointRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPoint), nameof(AccessPoint.Id), id);

                return _mapper.Map<AccessPointDto>(repResponse);
            }, nameof(GetByIdAsync));
        }

        public async Task UpdateAsync(UpdateAccessPointReq request, CancellationToken cancellationToken = default)
        {
            await _logger.HandleOperationAsync(async () =>
            {
                var repReq = await _accessPointRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(AccessPoint));

                _mapper.Map(request, repReq);
                await _accessPointRepository.UpdateAsync(repReq, cancellationToken);
            }, nameof(UpdateAsync));
        }

        public async Task<HeartbeatResponse> UpdateHeartbeatAsync(HeartbeatReq request, CancellationToken cancellationToken = default)
        {
            return await _logger.HandleOperationAsync(async () =>
            {
                var accessPoint = await _accessPointRepository.GetByIdAsync(request.AccessPointId, cancellationToken);
                
                if (accessPoint == null)
                {
                    _logger.LogWarning("Heartbeat получен для несуществующей точки доступа с ID: {AccessPointId}", request.AccessPointId);
                    return new HeartbeatResponse { Success = false };
                }

                // Обновляем время последнего heartbeat
                accessPoint.LastHeartbeatAt = request.TimeStamp;
                await _accessPointRepository.UpdateAsync(accessPoint, cancellationToken);
                
                _logger.LogInformation("Обновлен heartbeat для точки доступа {AccessPointId} ({Name}) на {TimeStamp}", 
                    accessPoint.Id, accessPoint.Name, request.TimeStamp);

                // Получаем активные уведомления для точки доступа
                var notifications = await _notificationService.GetNotificationsByAccessPointAsync(
                    request.AccessPointId, 
                    cancellationToken);

                // Фильтруем уведомления, которые не должны показываться при проходе
                var notificationsToShow = notifications
                    .Where(n => !n.ShowOnPass)
                    .ToList();
                
                return new HeartbeatResponse 
                { 
                    Success = true,
                    Notifications = notificationsToShow
                };
            }, nameof(UpdateHeartbeatAsync));
        }
    }
}
