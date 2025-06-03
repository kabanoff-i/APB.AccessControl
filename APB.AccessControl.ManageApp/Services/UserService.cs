using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            var response = await _apiService.GetAllUsersAsync();
            return response.Data;
        }
        
        /// <summary>
        /// Получение списка всех ролей
        /// </summary>
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            try
            {
                var response = await _apiService.GetAllRolesAsync();
                if (!response.IsSuccess)
                {
                    throw new Exception(response.Error?.Message ?? "Ошибка получения списка ролей");
                }

                if (response.Data == null || !response.Data.Any())
                {
                    throw new Exception("Список ролей пуст");
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "Ошибка при получении списка ролей");
                throw;
            }
        }
        
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        public async Task<UserDto> CreateUserAsync(RegisterRequest request)
        {
            var response = await _apiService.CreateUserAsync(request);
            return response.Data;
        }
        
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        public async Task<UserDto> UpdateUserAsync(UpdateUserReq request)
        {
            var response = await _apiService.UpdateUserAsync(request);
            return response.Data;
        }
        
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public async Task DeleteUserAsync(string userId)
        {
            await _apiService.DeleteUserAsync(userId);
        }
        
        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        public async Task ChangePasswordAsync(ChangePasswordReq request)
        {
            await _apiService.ChangePasswordAsync(request);
        }
        
        /// <summary>
        /// Назначение ролей пользователю
        /// </summary>
        public async Task AssignRolesAsync(string userName, List<string> roles)
        {
            foreach (var role in roles)
            {
                var userRole = new UserRole
                {
                    Username = userName,
                    Role = role
                };
                var response = await _apiService.AssignRoleAsync(userRole);
                if (!response.IsSuccess)
                {
                    throw new Exception(response.Error?.Message ?? "Ошибка назначения ролей");
                }
            }
        }
    }
} 