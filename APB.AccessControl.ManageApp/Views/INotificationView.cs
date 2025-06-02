using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления уведомлениями
    /// </summary>
    public interface INotificationView
    {
        /// <summary>
        /// Установка списка уведомлений
        /// </summary>
        void SetNotifications(IEnumerable<NotificationDto> notifications);

        /// <summary>
        /// Отображение сообщения пользователю
        /// </summary>
        void ShowMessage(string message);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        void ShowError(string message);
    }
} 