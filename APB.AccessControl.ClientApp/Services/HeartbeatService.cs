using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ClientApp.Services
{
    public class HeartbeatService
    {
        // Пустой класс, функциональность отключена
        public event EventHandler<NotificationEventArgs> OnNotificationReceived;
        
        public HeartbeatService(ApiService apiService, NotificationService notificationService)
        {
            // Конструктор оставлен для совместимости
        }
        
        public void Start()
        {
            // Метод оставлен для совместимости
        }
        
        public void Stop()
        {
            // Метод оставлен для совместимости
        }
    }

    public class NotificationEventArgs : EventArgs
    {
        public NotificationDto Notification { get; }

        public NotificationEventArgs(NotificationDto notification)
        {
            Notification = notification;
        }
    }
} 