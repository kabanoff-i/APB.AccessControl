using System;

namespace APB.AccessControl.Shared.Models.Filters
{
    /// <summary>
    /// Фильтр для логов доступа
    /// </summary>
    public class AccessLogFilter
    {
        /// <summary>
        /// Идентификатор карты
        /// </summary>
        public int? CardId { get; set; }
        
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int? EmployeeId { get; set; }
        
        /// <summary>
        /// Идентификатор точки доступа
        /// </summary>
        public int? AccessPointId { get; set; }
        
        /// <summary>
        /// Начальная дата и время
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Конечная дата и время
        /// </summary>
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Результат доступа
        /// </summary>
        public int? AccessResult { get; set; }
    }
} 