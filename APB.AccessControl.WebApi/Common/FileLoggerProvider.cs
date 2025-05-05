using System;
using System.Collections.Concurrent;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APB.AccessControl.WebApi.Common
{
    [ProviderAlias("File")]
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly IDisposable _onChangeToken;
        private FileLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, FileLogger> _loggers = new();

        public FileLoggerProvider(IOptionsMonitor<FileLoggerConfiguration> config)
        {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new FileLogger(name, GetCurrentConfig));
        }

        private FileLoggerConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose()
        {
            _loggers.Clear();
            _onChangeToken.Dispose();
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly Func<FileLoggerConfiguration> _getCurrentConfig;
        private static readonly object _lock = new object();

        public FileLogger(string categoryName, Func<FileLoggerConfiguration> getCurrentConfig)
        {
            _categoryName = categoryName;
            _getCurrentConfig = getCurrentConfig;
        }

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel)
        {
            var config = _getCurrentConfig();
            return config.LogLevels.ContainsKey(logLevel) && 
                   config.LogLevels[logLevel];
        }

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception? exception, 
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var config = _getCurrentConfig();
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var logDirectory = config.LogDirectory;
            var fileName = $"{config.FileNamePrefix}{DateTime.Now:yyyyMMdd}.log";
            var filePath = Path.Combine(logDirectory, fileName);

            var logRecord = formatter(state, exception);

            try
            {
                // Создаем директорию, если не существует
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                lock (_lock)
                {
                    // Формируем запись в лог
                    var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{logLevel}] [{_categoryName}] {logRecord}";
                    
                    // Добавляем информацию об исключении, если оно есть
                    if (exception != null)
                    {
                        logEntry += $"{Environment.NewLine}Exception: {exception.Message}";
                        logEntry += $"{Environment.NewLine}StackTrace: {exception.StackTrace}";
                        
                        if (exception.InnerException != null)
                        {
                            logEntry += $"{Environment.NewLine}Inner Exception: {exception.InnerException.Message}";
                            logEntry += $"{Environment.NewLine}Inner StackTrace: {exception.InnerException.StackTrace}";
                        }
                    }

                    // Пишем запись в файл
                    File.AppendAllText(filePath, logEntry + Environment.NewLine);
                }
            }
            catch
            {
                // Если не удалось записать в файл, игнорируем исключение
                // Чтобы не создавать бесконечный цикл логирования
            }
        }
    }

    public class FileLoggerConfiguration
    {
        // Установим значения по умолчанию - они будут заменены значениями из appsettings.json
        public string LogDirectory { get; set; } = string.Empty;
        public string FileNamePrefix { get; set; } = string.Empty;
        public Dictionary<LogLevel, bool> LogLevels { get; set; } = new();
    }
} 