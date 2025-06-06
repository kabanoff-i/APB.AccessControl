using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using APB.AccessControl.ClientApp.Resources;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ClientApp.Services
{
    public class HeartbeatService
    {
        private readonly ApiService _apiService;
        private readonly NotificationService _notificationService;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _heartbeatTask;
        private readonly TimeSpan _heartbeatInterval = TimeSpan.FromSeconds(30);

        public event EventHandler<NotificationEventArgs> OnNotificationReceived;

        public HeartbeatService(ApiService apiService, NotificationService notificationService)
        {
            _apiService = apiService;
            _notificationService = notificationService;
        }

        public void Start()
        {
            if (_heartbeatTask != null && !_heartbeatTask.IsCompleted)
                return;

            _cancellationTokenSource = new CancellationTokenSource();
            _heartbeatTask = Task.Run(async () => await HeartbeatLoop(_cancellationTokenSource.Token));
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _heartbeatTask?.Wait();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
            _heartbeatTask = null;
        }

        private async Task HeartbeatLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var response = await _apiService.Heartbeat();
                    ProcessNotifications(response.Notifications);
                    await Task.Delay(_heartbeatInterval, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"Не удалось выполнить heartbeat: {ex.Message}",
                        "Ошибка соединения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                }
            }
        }

        private void ProcessNotifications(List<NotificationDto> notifications)
        {
            if (notifications == null || notifications.Count == 0)
                return;

            foreach (var notification in notifications)
            {
                if (notification.ShowOnPass)
                {
                    // Уведомления для показа при проходе будут обработаны в AccessCheck
                    OnNotificationReceived?.Invoke(this, new NotificationEventArgs(notification));
                }
                else
                {
                    // Показываем обычные уведомления сразу
                    _notificationService.ShowNotification(
                        notification.AccessPointName,
                        notification.Message
                    );
                }
            }
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