using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Services
{
    /// <summary>
    /// Сервис для логирования ошибок и информации
    /// </summary>
    public static class LogService
    {
        private static readonly string LogDirectory = Settings.Default.LogFilePath;
        private static readonly string ErrorLogFileName = Settings.Default.LogFileName;
        private static readonly object _lockObject = new object();
        
        /// <summary>
        /// Записать ошибку в лог-файл
        /// </summary>
        /// <param name="error">Текст ошибки</param>
        /// <param name="source">Источник ошибки</param>
        public static void LogError(string error, string source = null)
        {
            Log($"ERROR: {(string.IsNullOrEmpty(source) ? "" : $"[{source}] ")}{error}");
        }
        
        /// <summary>
        /// Записать ошибку в лог-файл
        /// </summary>
        /// <param name="ex">Исключение</param>
        /// <param name="source">Источник ошибки</param>
        public static void LogError(Exception ex, string source = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ERROR: {(string.IsNullOrEmpty(source) ? "" : $"[{source}] ")}{ex.Message}");
            sb.AppendLine($"StackTrace: {ex.StackTrace}");
            
            if (ex.InnerException != null)
            {
                sb.AppendLine($"Inner Exception: {ex.InnerException.Message}");
                sb.AppendLine($"Inner StackTrace: {ex.InnerException.StackTrace}");
            }
            
            Log(sb.ToString());
        }
        
        /// <summary>
        /// Записать информацию в лог-файл
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="source">Источник сообщения</param>
        public static void LogInfo(string message, string source = null)
        {
            Log($"INFO: {(string.IsNullOrEmpty(source) ? "" : $"[{source}] ")}{message}");
        }
        
        /// <summary>
        /// Записать сообщение в лог-файл
        /// </summary>
        /// <param name="message">Сообщение для записи</param>
        private static void Log(string message)
        {
            try
            {
                // Проверяем наличие директории и создаем её при необходимости
                EnsureDirectoryExists();
                
                var logFilePath = Path.Combine(LogDirectory, ErrorLogFileName);
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var logMessage = $"[{timestamp}] {message}";
                
                // Синхронизируем доступ к файлу для избежания проблем при многопоточной записи
                lock (_lockObject)
                {
                    // Добавляем сообщение в файл
                    File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
                }
            }
            catch
            {
                // Игнорируем ошибки при логировании, чтобы избежать бесконечной рекурсии
            }
        }
        
        /// <summary>
        /// Проверяет наличие директории для логов и создает её при необходимости
        /// </summary>
        private static void EnsureDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }
            }
            catch
            {
                // Игнорируем ошибки при создании директории
            }
        }
        
        /// <summary>
        /// Асинхронный метод для записи ошибки в лог
        /// </summary>
        public static async Task LogErrorAsync(Exception ex, string source = null)
        {
            await Task.Run(() => LogError(ex, source));
        }
        
        /// <summary>
        /// Асинхронный метод для записи ошибки в лог
        /// </summary>
        public static async Task LogErrorAsync(string error, string source = null)
        {
            await Task.Run(() => LogError(error, source));
        }
        
        /// <summary>
        /// Асинхронный метод для записи информации в лог
        /// </summary>
        public static async Task LogInfoAsync(string message, string source = null)
        {
            await Task.Run(() => LogInfo(message, source));
        }
    }
} 