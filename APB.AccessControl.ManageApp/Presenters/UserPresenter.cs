using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using System;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для управления пользователями
    /// </summary>
    public class UserPresenter : IDisposable
    {
        private readonly IUserView _view;
        private readonly UserService _userService;
        private bool _isDisposed;
        
        /// <summary>
        /// Конструктор презентера
        /// </summary>
        public UserPresenter(IUserView view, UserService userService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            
            // Подписываемся на события представления
            _view.RefreshData += HandleRefreshData;
            _view.CreateUser += HandleCreateUser;
            _view.UpdateUser += HandleUpdateUser;
            _view.DeleteUser += HandleDeleteUser;
            _view.ChangePassword += HandleChangePassword;
        }
        
        /// <summary>
        /// Асинхронная инициализация презентера
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при инициализации: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Загрузка данных
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                // Загружаем список пользователей
                var users = await _userService.GetAllUsersAsync();
                _view.SetUsers(users);
                
                // Загружаем список ролей
                var roles = await _userService.GetAllRolesAsync();
                _view.SetRoles(roles);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события обновления данных
        /// </summary>
        private async void HandleRefreshData(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        
        /// <summary>
        /// Обработчик события создания пользователя
        /// </summary>
        private async void HandleCreateUser(object sender, CreateUserReq e)
        {
            try
            {
                await _userService.CreateUserAsync(e);
                _view.ShowMessage("Пользователь успешно создан");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при создании пользователя: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события обновления пользователя
        /// </summary>
        private async void HandleUpdateUser(object sender, UpdateUserReq e)
        {
            try
            {
                await _userService.UpdateUserAsync(e);
                _view.ShowMessage("Пользователь успешно обновлен");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при обновлении пользователя: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события удаления пользователя
        /// </summary>
        private async void HandleDeleteUser(object sender, int userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);
                _view.ShowMessage("Пользователь успешно удален");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при удалении пользователя: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события изменения пароля
        /// </summary>
        private async void HandleChangePassword(object sender, ChangePasswordReq e)
        {
            try
            {
                await _userService.ChangePasswordAsync(e);
                _view.ShowMessage("Пароль успешно изменен");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при изменении пароля: {ex.Message}");
            }
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
                _view.CreateUser -= HandleCreateUser;
                _view.UpdateUser -= HandleUpdateUser;
                _view.DeleteUser -= HandleDeleteUser;
                _view.ChangePassword -= HandleChangePassword;
            }
            
            _isDisposed = true;
        }
    }
} 