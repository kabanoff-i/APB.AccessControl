using System;

namespace APB.AccessControl.ManageApp.Models.Auth
{
    /// <summary>
    /// Результат логина пользователя
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// Токен JWT для авторизации запросов
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Время истечения срока действия токена
        /// </summary>
        public DateTime ExpiresAt { get; set; }
        
        /// <summary>
        /// Успешен ли вход
        /// </summary>
        public bool IsSuccess { get; set; }
        
        /// <summary>
        /// Сообщение об ошибке (если есть)
        /// </summary>
        public string ErrorMessage { get; set; }
    }
} 