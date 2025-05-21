using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с правилами доступа
    /// </summary>
    public class AccessRuleService
    {
        private readonly ApiService _apiService;
        
        public AccessRuleService(ApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }
        
        /// <summary>
        /// Получить все правила доступа
        /// </summary>
        public async Task<IEnumerable<AccessRuleDto>> GetAllAsync()
        {
            var response = await _apiService.GetAccessRulesAsync();
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения списка правил доступа");
        }
        
        /// <summary>
        /// Получить правила доступа для группы
        /// </summary>
        public async Task<IEnumerable<AccessRuleDto>> GetByGroupAsync(int accessGroupId)
        {
            var response = await _apiService.GetAccessRulesByGroupAsync(accessGroupId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения правил доступа для группы");
        }
        
        /// <summary>
        /// Получить правила доступа для точки доступа
        /// </summary>
        public async Task<IEnumerable<AccessRuleDto>> GetByAccessPointAsync(int accessPointId)
        {
            var response = await _apiService.GetAccessRulesByPointAsync(accessPointId);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения правил доступа для точки доступа");
        }
        
        /// <summary>
        /// Получить правило доступа по идентификатору
        /// </summary>
        public async Task<AccessRuleDto> GetByIdAsync(int id)
        {
            var response = await _apiService.GetAccessRuleByIdAsync(id);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка получения данных правила доступа");
        }
        
        /// <summary>
        /// Создать новое правило доступа
        /// </summary>
        public async Task<AccessRuleDto> CreateAsync(CreateAccessRuleReq request)
        {
            var response = await _apiService.CreateAccessRuleAsync(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка создания правила доступа");
        }
        
        /// <summary>
        /// Обновить существующее правило доступа
        /// </summary>
        public async Task<AccessRuleDto> UpdateAsync(UpdateAccessRuleReq request)
        {
            var response = await _apiService.UpdateAccessRuleAsync(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            
            throw new Exception(response.Error?.Message ?? "Ошибка обновления правила доступа");
        }
        
        /// <summary>
        /// Удалить правило доступа
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var response = await _apiService.DeleteAccessRuleAsync(id);
            if (!response.IsSuccess)
            {
                throw new Exception(response.Error?.Message ?? "Ошибка удаления правила доступа");
            }
        }
    }
} 