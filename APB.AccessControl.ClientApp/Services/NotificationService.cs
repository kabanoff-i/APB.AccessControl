using DevExpress.XtraBars.Alerter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using APB.AccessControl.Shared.Models.DTOs;
using System.Linq;

namespace APB.AccessControl.ClientApp.Services
{
    public class NotificationService
    {
        private readonly AlertControl _alertControl;
        private readonly Form _owner;
        private readonly List<NotificationDto> _notifications = new List<NotificationDto>();
        private readonly Dictionary<int, Action<NotificationDto>> _notificationCallbacks = new Dictionary<int, Action<NotificationDto>>();

        public event EventHandler OnNotificationsChanged;

        public NotificationService(AlertControl alertControl, Form owner)
        {
            _alertControl = alertControl ?? throw new ArgumentNullException(nameof(alertControl));
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            _alertControl.AlertClick += AlertControl_AlertClick;
        }

        public void ShowNotification(string title, string message, Action<NotificationDto> onClick = null)
        {
            if (_owner.InvokeRequired)
            {
                _owner.Invoke(new Action(() => ShowNotification(title, message, onClick)));
                return;
            }

            var notification = new NotificationDto
            {
                Id = _notifications.Count + 1,
                AccessPointName = title,
                Message = message
            };

            _notifications.Add(notification);
            if (onClick != null)
            {
                _notificationCallbacks[notification.Id] = onClick;
            }

            var alertInfo = new AlertInfo(title, message);
            _alertControl.Show(_owner, alertInfo);
            OnNotificationsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AlertControl_AlertClick(object sender, AlertClickEventArgs e)
        {
            var notification = _notifications.FirstOrDefault(n => n.AccessPointName == e.Info.Caption);
            if (notification != null && _notificationCallbacks.TryGetValue(notification.Id, out var callback))
            {
                callback(notification);
            }
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            return _notifications;
        }

        public void AddNotification(NotificationDto notification)
        {
            _notifications.Add(notification);
            OnNotificationsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void MarkAsRead(NotificationDto notification)
        {
            var existing = _notifications.Find(n => n.Id == notification.Id);
            if (existing != null)
            {
                existing.IsRead = true;
                OnNotificationsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public IEnumerable<NotificationDto> GetNotifications(bool onlyUnread = false)
        {
            return onlyUnread 
                ? _notifications.FindAll(n => !n.IsRead)
                : _notifications;
        }

        public void ShowError(string title, string message)
        {
            if (_owner.InvokeRequired)
            {
                _owner.Invoke(new Action(() => ShowError(title, message)));
                return;
            }

            var alertInfo = new AlertInfo(title, message)
            {
                Image = SystemIcons.Error.ToBitmap()
            };
            _alertControl.Show(_owner, alertInfo);
        }
    }
} 