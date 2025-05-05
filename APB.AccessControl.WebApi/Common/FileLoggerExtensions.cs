using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Configuration;

namespace APB.AccessControl.WebApi.Common
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, FileLoggerProvider>());
            
            LoggerProviderOptions.RegisterProviderOptions<FileLoggerConfiguration, FileLoggerProvider>(builder.Services);
            
            return builder;
        }
        
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, Action<FileLoggerConfiguration> configure)
        {
            builder.AddFile();
            builder.Services.Configure(configure);
            
            return builder;
        }
        
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, IConfiguration configuration)
        {
            builder.AddFile();
            
            // Получаем конфигурацию из секции "Logging:File"
            var configSection = configuration.GetSection("Logging:File");
            builder.Services.Configure<FileLoggerConfiguration>(configSection);
            
            return builder;
        }
    }
} 