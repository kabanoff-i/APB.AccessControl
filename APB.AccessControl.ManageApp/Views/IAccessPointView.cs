using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления точками доступа
    /// </summary>
    public interface IAccessPointView
    {
        /// <summary>
        /// Событие добавления новой точки доступа
        /// </summary>
        event EventHandler AddAccessPoint;
        
        /// <summary>
        /// Событие редактирования точки доступа
        /// </summary>
        event EventHandler<int> EditAccessPoint;
        
        /// <summary>
        /// Событие удаления точки доступа
        /// </summary>
        event EventHandler<int> DeleteAccessPoint;
        
        /// <summary>
        /// Событие просмотра правил точки доступа
        /// </summary>
        event EventHandler<int> ViewAccessPointRules;
        
        /// <summary>
        /// Событие отправки уведомления на точку доступа
        /// </summary>
        event EventHandler<int> SendNotification;
        
        /// <summary>
        /// Событие обновления данных
        /// </summary>
        event EventHandler RefreshData;
        
        /// <summary>
        /// Установить список точек доступа в представление
        /// </summary>
        void SetAccessPoints(IEnumerable<AccessPointDto> accessPoints);
        
        /// <summary>
        /// Получить выбранный идентификатор точки доступа
        /// </summary>
        int GetSelectedAccessPointId();
        
        /// <summary>
        /// Очистить выбор точки доступа
        /// </summary>
        void ClearSelection();
        
        /// <summary>
        /// Отобразить сообщение пользователю
        /// </summary>
        void ShowMessage(string message);
        
        /// <summary>
        /// Отобразить сообщение об ошибке
        /// </summary>
        void ShowError(string message);
    }
} 