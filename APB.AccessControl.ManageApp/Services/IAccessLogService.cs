using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами доступа
    /// </summary>
    public interface IAccessLogService
    {
        /// <summary>
        /// Получение логов доступа по фильтру
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <param name="employeeId">Идентификатор сотрудника (0 - все сотрудники)</param>
        /// <param name="accessPointId">Идентификатор точки доступа (0 - все точки)</param>
        /// <returns>Список логов доступа</returns>
        Task<IEnumerable<AccessLogDto>> GetLogsAsync(DateTime startDate, DateTime endDate, int employeeId = 0, int accessPointId = 0);
    }
} 