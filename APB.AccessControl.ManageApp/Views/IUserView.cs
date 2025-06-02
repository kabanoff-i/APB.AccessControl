using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления пользователями
    /// </summary>
    public interface IUserView
    {
        /// <summary>
        /// Событие запроса обновления данных
        /// </summary>
        event EventHandler RefreshData;
        
        /// <summary>
        /// Событие создания нового пользователя
        /// </summary>
        event EventHandler<CreateUserReq> CreateUser;
        
        /// <summary>
        /// Событие обновления пользователя
        /// </summary>
        event EventHandler<UpdateUserReq> UpdateUser;
        
        /// <summary>
        /// Событие удаления пользователя
        /// </summary>
        event EventHandler<int> DeleteUser;
        
        /// <summary>
        /// Событие изменения пароля
        /// </summary>
        event EventHandler<ChangePasswordReq> ChangePassword;
        
        /// <summary>
        /// Установка списка пользователей
        /// </summary>
        void SetUsers(IEnumerable<UserDto> users);
        
        /// <summary>
        /// Установка списка ролей
        /// </summary>
        void SetRoles(IEnumerable<RoleDto> roles);
        
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