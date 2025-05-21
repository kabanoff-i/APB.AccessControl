using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с точками доступа
    /// </summary>
    public class AccessPointService
    {
        private readonly ApiService _apiService;
        
        public AccessPointService()
        {
            _apiService = new ApiService();
        }
        
        /// <summary>
        /// Получить все точки доступа
        /// </summary>
        public async Task<IEnumerable<AccessPointDto>> GetAllAsync()
        {
            var response = await _apiService.GetAccessPointsAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения списка точек доступа");
        }
        
        /// <summary>
        /// Получить точку доступа по идентификатору
        /// </summary>
        public async Task<AccessPointDto> GetByIdAsync(int id)
        {
            var response = await _apiService.GetAccessPointByIdAsync(id);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения данных точки доступа");
        }
        
        /// <summary>
        /// Создать новую точку доступа
        /// </summary>
        public async Task<AccessPointDto> CreateAsync(CreateAccessPointReq request)
        {
            var response = await _apiService.CreateAccessPointAsync(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка создания точки доступа");
        }
        
        /// <summary>
        /// Обновить существующую точку доступа
        /// </summary>
        public async Task UpdateAsync(UpdateAccessPointReq request)
        {
            var response = await _apiService.UpdateAccessPointAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка обновления точки доступа");
            }
        }
        
        /// <summary>
        /// Удалить точку доступа
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var response = await _apiService.DeleteAccessPointAsync(id);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка удаления точки доступа");
            }
        }
        
        /// <summary>
        /// Получить все типы точек доступа
        /// </summary>
        public async Task<IEnumerable<AccessPointTypeDto>> GetAllTypesAsync()
        {
            var response = await _apiService.GetAccessPointTypesAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения типов точек доступа");
        }
        
        /// <summary>
        /// Отправить heartbeat для точки доступа
        /// </summary>
        public async Task SendHeartbeatAsync(HeartbeatReq request)
        {
            var response = await _apiService.SendHeartbeatAsync(request);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка отправки heartbeat");
            }
        }
    }
} 