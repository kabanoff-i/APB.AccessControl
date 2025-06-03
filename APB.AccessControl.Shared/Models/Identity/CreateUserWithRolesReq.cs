using System.Collections.Generic;

namespace APB.AccessControl.Shared.Models.Identity
{
    /// <summary>
    /// Запрос на создание пользователя с ролями
    /// </summary>
    public class CreateUserWithRolesReq
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Список ролей
        /// </summary>
        public List<string> Roles { get; set; }
    }
} 