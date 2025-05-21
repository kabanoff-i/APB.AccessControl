using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для работы с логами доступа
    /// </summary>
    public interface IAccessLogView
    {
        /// <summary>
        /// Событие запроса обновления данных
        /// </summary>
        event EventHandler RefreshData;
        
        /// <summary>
        /// Событие фильтрации логов
        /// </summary>
        event EventHandler<LogFilterOptions> FilterLogs;
        
        /// <summary>
        /// Установка списка логов доступа
        /// </summary>
        /// <param name="logs">Список логов доступа</param>
        void SetAccessLogs(IEnumerable<AccessLogDto> logs);
        
        /// <summary>
        /// Установка списка сотрудников для фильтрации
        /// </summary>
        /// <param name="employees">Список сотрудников</param>
        void SetEmployees(IEnumerable<EmployeeDto> employees);
        
        /// <summary>
        /// Установка списка точек доступа для фильтрации
        /// </summary>
        /// <param name="accessPoints">Список точек доступа</param>
        void SetAccessPoints(IEnumerable<AccessPointDto> accessPoints);
        
        /// <summary>
        /// Отображение сообщения пользователю
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowMessage(string message);
        
        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке</param>
        void ShowError(string message);
    }
    
    /// <summary>
    /// Класс для хранения параметров фильтрации логов
    /// </summary>
    public class LogFilterOptions
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }
        public int AccessPointId { get; set; }
    }
} 