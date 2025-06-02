using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserService
    {
        private readonly ApiService _apiService;
        
        public UserService(ApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }
        
        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _apiService.GetAsync<IEnumerable<UserDto>>("api/users");
        }
        
        /// <summary>
        /// Получение списка всех ролей
        /// </summary>
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            return await _apiService.GetAsync<IEnumerable<RoleDto>>("api/roles");
        }
        
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        public async Task<UserDto> CreateUserAsync(CreateUserReq request)
        {
            return await _apiService.PostAsync<UserDto>("api/users", request);
        }
        
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        public async Task<UserDto> UpdateUserAsync(UpdateUserReq request)
        {
            return await _apiService.PutAsync<UserDto>($"api/users/{request.Id}", request);
        }
        
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public async Task DeleteUserAsync(int userId)
        {
            await _apiService.DeleteAsync($"api/users/{userId}");
        }
        
        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        public async Task ChangePasswordAsync(ChangePasswordReq request)
        {
            await _apiService.PostAsync("api/users/change-password", request);
        }
    }
} 