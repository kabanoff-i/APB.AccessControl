using APB.AccessControl.ManageApp.Forms;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для управления точками доступа
    /// </summary>
    public class AccessPointPresenter
    {
        private readonly IAccessPointView _view;
        private readonly AccessPointService _accessPointService;
        private readonly System.Windows.Forms.Timer _refreshTimer;
        private IEnumerable<AccessPointDto> _accessPoints;
        private int? _selectedAccessPointId;

        public AccessPointPresenter(IAccessPointView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _accessPointService = new AccessPointService();

            // Настройка таймера обновления данных каждую минуту
            _refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 60000 // 1 минута в миллисекундах
            };
            _refreshTimer.Tick += async (sender, e) => await RefreshDataAsync();

            // Подписка на события представления
            _view.AddAccessPoint += async (sender, e) => await AddAccessPointAsync();
            _view.EditAccessPoint += async (sender, e) => await EditAccessPointAsync(e);
            _view.DeleteAccessPoint += async (sender, e) => await DeleteAccessPointAsync(e);
            _view.ViewAccessPointRules += OnViewAccessPointRules;
            _view.SendNotification += OnSendNotification;
            _view.RefreshData += async (sender, e) => await RefreshDataAsync();

            Task.Run(RefreshDataAsync);
            _refreshTimer.Start();
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            _refreshTimer.Stop();
            _refreshTimer.Dispose();
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private async Task RefreshDataAsync()
        {
            try
             {
                // Сохраняем текущий выбранный ID
                _selectedAccessPointId = _view.GetSelectedAccessPointId();

                // Получаем все точки доступа через сервис
                _accessPoints = await _accessPointService.GetAllAsync();
                _view.SetAccessPoints(_accessPoints);

                // Восстанавливаем выбор, если он был
                if (_selectedAccessPointId.HasValue && _selectedAccessPointId > 0)
                {
                    // Проверяем, существует ли еще выбранная точка доступа
                    var exists = _accessPoints.Any(ap => ap.Id == _selectedAccessPointId.Value);
                    if (!exists)
                    {
                        _view.ClearSelection();
                        _selectedAccessPointId = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при получении данных: {ex.Message}");
            }
        }

        /// <summary>
        /// Добавление новой точки доступа
        /// </summary>
        private async Task AddAccessPointAsync()
        {
            try
            {
                // Получаем типы точек доступа для выпадающего списка
                var types = await GetAccessPointTypesAsync();
                if (types == null)
                {
                    return; // Сообщение об ошибке уже показано в GetAccessPointTypesAsync
                }

                // Открываем форму для добавления точки доступа
                using (var form = new AccessPointEditForm(null, types))
                {
                    if (form.ShowDialog() != DialogResult.OK) return;

                    // Создаем запрос на добавление точки доступа
                    var request = new CreateAccessPointReq
                    {
                        Name = form.AccessPointData.Name,
                        Location = form.AccessPointData.Location,
                        IpAddress = form.AccessPointData.IpAddress,
                        AccessPointTypeId = form.AccessPointData.AccessPointTypeId
                    };

                    // Отправляем запрос через сервис
                    await _accessPointService.CreateAsync(request);
                    _view.ShowMessage("Точка доступа успешно добавлена");
                    await RefreshDataAsync();
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при добавлении точки доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Редактирование точки доступа
        /// </summary>
        private async Task EditAccessPointAsync(int accessPointId)
        {
            try
            {
                // Получаем данные точки доступа для редактирования
                var accessPoint = _accessPoints.FirstOrDefault(ap => ap.Id == accessPointId);
                if (accessPoint == null)
                {
                    _view.ShowError("Точка доступа не найдена");
                    return;
                }

                // Получаем типы точек доступа для выпадающего списка
                var types = await GetAccessPointTypesAsync();
                if (types == null)
                {
                    return; // Сообщение об ошибке уже показано в GetAccessPointTypesAsync
                }

                // Открываем форму для редактирования
                using (var form = new AccessPointEditForm(accessPoint, types))
                {
                    if (form.ShowDialog() != DialogResult.OK) return;

                    // Создаем запрос на обновление точки доступа
                    var request = new UpdateAccessPointReq
                    {
                        Id = accessPointId,
                        Name = form.AccessPointData.Name,
                        Location = form.AccessPointData.Location,
                        IpAddress = form.AccessPointData.IpAddress,
                        AccessPointTypeId = form.AccessPointData.AccessPointTypeId,
                        IsActive = form.AccessPointData.IsActive
                    };

                    // Отправляем запрос через сервис
                    await _accessPointService.UpdateAsync(request);
                    _view.ShowMessage("Точка доступа успешно обновлена");
                    await RefreshDataAsync();
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при редактировании точки доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаление точки доступа
        /// </summary>
        private async Task DeleteAccessPointAsync(int accessPointId)
        {
            try
            {
                // Запрос подтверждения удаления
                if (MessageBox.Show("Вы действительно хотите удалить точку доступа?", "Подтверждение удаления", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                // Отправляем запрос через сервис
                await _accessPointService.DeleteAsync(accessPointId);
                _view.ShowMessage("Точка доступа успешно удалена");
                _view.ClearSelection();
                await RefreshDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при удалении точки доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик просмотра правил точки доступа
        /// </summary>
        private void OnViewAccessPointRules(object sender, int accessPointId)
        {
            // TODO: Реализовать просмотр правил точки доступа
            _view.ShowMessage("Просмотр правил точки доступа будет добавлен позже");
        }

        /// <summary>
        /// Обработчик отправки уведомления на точку доступа
        /// </summary>
        private void OnSendNotification(object sender, int accessPointId)
        {
            // TODO: Реализовать отправку уведомления на точку доступа
            _view.ShowMessage("Отправка уведомлений будет добавлена позже");
        }

        /// <summary>
        /// Получение списка типов точек доступа
        /// </summary>
        private async Task<IEnumerable<AccessPointTypeDto>> GetAccessPointTypesAsync()
        {
            try
            {
                return await _accessPointService.GetAllTypesAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при получении типов точек доступа: {ex.Message}");
                return null;
            }
        }
    }
} 