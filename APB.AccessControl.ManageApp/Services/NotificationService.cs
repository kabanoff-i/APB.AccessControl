using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с уведомлениями
    /// </summary>
    public class NotificationService
    {
        private readonly ApiService _apiService;

        public NotificationService()
        {
            _apiService = new ApiService();
        }

        /// <summary>
        /// Получение списка всех уведомлений
        /// </summary>
        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            var response = await _apiService.GetNotificationsAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения списка уведомлений");
        }

        /// <summary>
        /// Получение уведомления по идентификатору
        /// </summary>
        public async Task<NotificationDto> GetByIdAsync(int id)
        {
            var response = await _apiService.GetNotificationByIdAsync(id);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения уведомления");
        }

        /// <summary>
        /// Создание нового уведомления
        /// </summary>
        public async Task<NotificationDto> CreateAsync(CreateNotificationReq request)
        {
            var response = await _apiService.CreateNotificationAsync(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка создания уведомления");
        }

        /// <summary>
        /// Обновление уведомления
        /// </summary>
        public async Task UpdateAsync(UpdateNotificationReq request)
        {
            var response = await _apiService.UpdateNotificationAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка обновления уведомления");
            }
        }

        /// <summary>
        /// Удаление уведомления
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var response = await _apiService.DeleteNotificationAsync(id);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка удаления уведомления");
            }
        }

        /// <summary>
        /// Получение уведомлений для точки доступа
        /// </summary>
        public async Task<IEnumerable<NotificationDto>> GetByAccessPointAsync(int accessPointId)
        {
            var response = await _apiService.GetNotificationsByAccessPointAsync(accessPointId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения уведомлений для точки доступа");
        }

        /// <summary>
        /// Получение уведомлений для сотрудника
        /// </summary>
        public async Task<IEnumerable<NotificationDto>> GetByEmployeeAsync(int employeeId)
        {
            var response = await _apiService.GetNotificationsByEmployeeAsync(employeeId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения уведомлений для сотрудника");
        }
    }
} 