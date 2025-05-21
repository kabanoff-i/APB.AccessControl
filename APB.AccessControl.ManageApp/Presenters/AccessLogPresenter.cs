using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для работы с логами доступа
    /// </summary>
    public class AccessLogPresenter : IDisposable
    {
        private readonly IAccessLogView _view;
        private readonly IAccessLogService _accessLogService;
        private readonly EmployeeService _employeeService;
        private readonly AccessPointService _accessPointService;
        
        private bool _isDisposed;
        
        /// <summary>
        /// Конструктор презентера логов доступа
        /// </summary>
        public AccessLogPresenter(
            IAccessLogView view,
            IAccessLogService accessLogService,
            EmployeeService employeeService,
            AccessPointService accessPointService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _accessLogService = accessLogService ?? throw new ArgumentNullException(nameof(accessLogService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _accessPointService = accessPointService ?? throw new ArgumentNullException(nameof(accessPointService));
            
            // Подписываемся на события представления
            _view.RefreshData += HandleRefreshData;
            _view.FilterLogs += HandleFilterLogs;
        }
        
        /// <summary>
        /// Асинхронная инициализация презентера
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                // Загружаем справочники
                await LoadReferencesAsync();
                
                // Загружаем логи за последние 7 дней по умолчанию
                var defaultStartDate = DateTime.Now.AddDays(-7);
                var defaultEndDate = DateTime.Now;
                
                await LoadLogsAsync(defaultStartDate, defaultEndDate);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при инициализации: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Загрузка справочников для фильтрации
        /// </summary>
        private async Task LoadReferencesAsync()
        {
            try
            {
                // Загружаем список сотрудников
                var employees = await _employeeService.GetAllEmployeesAsync();
                _view.SetEmployees(employees);
                
                // Загружаем список точек доступа
                var accessPoints = await _accessPointService.GetAllAsync();
                _view.SetAccessPoints(accessPoints);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке справочников: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Загрузка логов доступа по фильтру
        /// </summary>
        private async Task LoadLogsAsync(DateTime startDate, DateTime endDate, int employeeId = 0, int accessPointId = 0)
        {
            try
            {
                // Получаем логи из сервиса
                var logs = await _accessLogService.GetLogsAsync(startDate, endDate, employeeId, accessPointId);
                
                // Если логи получены, обновляем представление
                if (logs != null && logs.Any())
                {
                    _view.SetAccessLogs(logs);
                }
                else
                {
                    _view.SetAccessLogs(Enumerable.Empty<AccessLogDto>());
                    _view.ShowMessage("Логи не найдены");
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке логов: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события обновления данных
        /// </summary>
        private async void HandleRefreshData(object sender, EventArgs e)
        {
            await LoadReferencesAsync();
        }
        
        /// <summary>
        /// Обработчик события фильтрации логов
        /// </summary>
        private async void HandleFilterLogs(object sender, LogFilterOptions e)
        {
            await LoadLogsAsync(e.StartDate, e.EndDate, e.EmployeeId, e.AccessPointId);
        }
        
        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            
            if (disposing)
            {
                // Отписываемся от событий
                _view.RefreshData -= HandleRefreshData;
                _view.FilterLogs -= HandleFilterLogs;
            }
            
            _isDisposed = true;
        }
    }
} 