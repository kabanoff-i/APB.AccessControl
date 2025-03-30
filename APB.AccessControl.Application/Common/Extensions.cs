using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using APB.AccessControl.Domain.Exceptions;
using FluentValidation;

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
                logger.LogWarning(ex, "Не найдена сущность при выполнении операции {OperationName}: {Message}", 
                    operationName, ex.Message);
                throw;
            }
            catch (ValidationException ex)
            {
                logger.LogWarning(ex, "Ошибка валидации при выполнении операции {OperationName}: {Errors}", 
                    operationName, string.Join(", ", ex.Errors));
                throw;
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex, "Некорректная операция {OperationName}: {Message}", 
                    operationName, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Критическая ошибка при выполнении операции {OperationName}: {Message}", 
                    operationName, ex.Message);
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
                logger.LogWarning(ex, "Не найдена сущность при выполнении операции {OperationName}: {Message}", 
                    operationName, ex.Message);
                throw;
            }
            catch (ValidationException ex)
            {
                logger.LogWarning(ex, "Ошибка валидации при выполнении операции {OperationName}: {Errors}", 
                    operationName, string.Join(", ", ex.Errors));
                throw;
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex, "Некорректная операция {OperationName}: {Message}", 
                    operationName, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Критическая ошибка при выполнении операции {OperationName}: {Message}", 
                    operationName, ex.Message);
                throw;
            }
        }
    }
}