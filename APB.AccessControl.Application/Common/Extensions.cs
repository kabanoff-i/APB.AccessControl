using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Domain.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Application.Services;

namespace APB.AccessControl.Application.Common
{
    public static class Extensions
    {
        public static async Task HandleOperationAsync(this ILogger logger, Func<Task> operation, string operationName)
        {
            try
            {
                await operation();
            }
            catch (NotFoundException ex)
            {
                logger.LogWarning(ex, $"Не найдена сущность при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
            catch (FluentValidation.ValidationException ex)
            {
                logger.LogWarning(ex, $"Ошибка валидации при выполнении операции {operationName}: {string.Join(", ", ex.Errors)}");
                throw;
            }
            catch (RepositoryException ex)
            {
                logger.LogError(ex, $"Ошибка при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex, $"Некорректная операция {operationName}: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Критическая ошибка при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
        }

        public static async Task<T> HandleOperationAsync<T>(this ILogger logger, Func<Task<T>> operation, string operationName)
        {
            try
            {
                return await operation();
            }
            catch (NotFoundException ex)
            {
                logger.LogWarning(ex, $"Не найдена сущность при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
            catch (FluentValidation.ValidationException ex)
            {
                logger.LogWarning(ex, $"Ошибка валидации при выполнении операции {operationName}: {string.Join(", ", ex.Errors)}");
                throw;
            }
            catch (RepositoryException ex)
            {
                logger.LogError(ex, $"Ошибка при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex, $"Некорректная операция {operationName}: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Критическая ошибка при выполнении операции {operationName}: {ex.Message}");
                throw;
            }
        }


        public static async Task HandleRepositoryExceptionAsync(this ILogger logger, Func<Task> operation, string operationName, object key)
        {
            try
            {
                await operation();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ошибка при выполнении операции {operationName}: {ex.Message}");
                throw new RepositoryException(ex, operationName, key);
            }
        }
        
        public static async Task<T> HandleRepositoryOperationAsync<T>(this ILogger logger, Func<Task<T>> operation, string operationName, object key)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ошибка при выполнении операции {operationName}: {ex.Message}");
                throw new RepositoryException(ex, operationName, key);
            }
        }

        public static async Task<T> HandleRepositoryOperationAsync<T>(this ILogger logger, Func<Task<T>> operation, string operationName)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ошибка при выполнении операции {operationName}: {ex.Message}");
                throw new RepositoryException(ex, operationName, null);
            }
        }
    }
}