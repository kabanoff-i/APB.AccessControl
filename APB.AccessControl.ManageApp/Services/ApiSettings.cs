using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Класс для хранения настроек API
    /// </summary>
    public static class ApiSettings
    {
        /// <summary>
        /// Базовый URL API
        /// </summary>
        public static string BaseUrl { get; set; } = Settings.Default.ApiBaseUrl;

        /// <summary>
        /// Токен авторизации
        /// </summary>
        public static string AuthToken { get; set; }

        /// <summary>
        /// Срок действия токена
        /// </summary>
        public static DateTime? TokenExpiry { get; set; }
    }
}
