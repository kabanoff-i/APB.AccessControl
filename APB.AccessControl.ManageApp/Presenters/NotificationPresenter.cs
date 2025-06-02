using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для управления уведомлениями
    /// </summary>
    public class NotificationPresenter : IDisposable
    {
        private readonly INotificationView _view;
        private readonly NotificationService _notificationService;
        private bool _disposed;

        public NotificationService NotificationService => _notificationService;

        public NotificationPresenter(INotificationView view, NotificationService notificationService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        /// <summary>
        /// Загрузка списка уведомлений
        /// </summary>
        public async Task LoadNotificationsAsync()
        {
            try
            {
                var notifications = await _notificationService.GetAllAsync();
                _view.SetNotifications(notifications);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке уведомлений: {ex.Message}");
            }
        }

        /// <summary>
        /// Создание нового уведомления
        /// </summary>
        public async Task CreateNotificationAsync(CreateNotificationReq request)
        {
            try
            {
                await _notificationService.CreateAsync(request);
                _view.ShowMessage("Уведомление успешно создано");
                await LoadNotificationsAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при создании уведомления: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновление уведомления
        /// </summary>
        public async Task UpdateNotificationAsync(UpdateNotificationReq request)
        {
            try
            {
                await _notificationService.UpdateAsync(request);
                _view.ShowMessage("Уведомление успешно обновлено");
                await LoadNotificationsAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при обновлении уведомления: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаление уведомления
        /// </summary>
        public async Task DeleteNotificationAsync(int id)
        {
            try
            {
                await _notificationService.DeleteAsync(id);
                _view.ShowMessage("Уведомление успешно удалено");
                await LoadNotificationsAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при удалении уведомления: {ex.Message}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }

                _disposed = true;
            }
        }
    }
} 