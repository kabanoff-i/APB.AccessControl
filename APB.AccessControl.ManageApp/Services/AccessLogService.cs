using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.Filters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с логами доступа
    /// </summary>
    public class AccessLogService
    {
        private readonly ApiService _apiService;
        
        /// <summary>
        /// Конструктор сервиса логов доступа
        /// </summary>
        /// <param name="apiService">Сервис API</param>
        public AccessLogService()
        {
            _apiService = new ApiService();
        }
        
        /// <summary>
        /// Получение логов доступа по фильтру
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <param name="employeeId">Идентификатор сотрудника (0 - все сотрудники)</param>
        /// <param name="accessPointId">Идентификатор точки доступа (0 - все точки)</param>
        /// <returns>Список логов доступа</returns>
        public async Task<IEnumerable<AccessLogDto>> GetLogsAsync(DateTime startDate, DateTime endDate, int employeeId = 0, int accessPointId = 0)
        {
            try
            {
                // Создаем объект фильтра
                var filter = new AccessLogFilterDto
                {
                    AccessTimeStart = startDate,
                    AccessTimeEnd = endDate,
                    EmployeeId = employeeId > 0 ? employeeId : null,
                    AccessPointId = accessPointId > 0 ? accessPointId : null
                };
                
                // Используем готовый метод из ApiService для получения логов
                var response = await _apiService.GetAccessLogsAsync(filter);
                
                // Проверяем успешность выполнения запроса
                if (response.IsSuccess && response.Data != null)
                {
                    return response.Data;
                }
                else
                {
                    // Логируем ошибку
                    LogService.LogError($"Ошибка при получении логов доступа: {response.Error?.Message}", "AccessLogService.GetLogsAsync");
                    
                    // Если есть сообщение об ошибке, передаем его в исключении
                    if (response.Error != null)
                    {
                        throw new Exception($"Ошибка при получении логов доступа: {response.Error.Message}");
                    }
                    
                    // Возвращаем пустой список
                    return Enumerable.Empty<AccessLogDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                LogService.LogError(ex, "AccessLogService.GetLogsAsync");
                throw new Exception($"Ошибка при получении логов доступа: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "AccessLogService.GetLogsAsync");
                throw new Exception($"Произошла ошибка: {ex.Message}", ex);
            }
        }
    }
} 