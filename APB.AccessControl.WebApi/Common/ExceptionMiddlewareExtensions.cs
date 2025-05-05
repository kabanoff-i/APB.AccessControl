using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared;
using System.Diagnostics;
using FluentValidation;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;
                    var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
                    var path = context.Request.Path;
                    var method = context.Request.Method;
                    
                    // Детальное логирование с информацией о запросе
                    logger.LogError(exception, 
                        "Ошибка при обработке запроса {Method} {Path}. TraceId: {TraceId}", 
                        method, path, traceId);

                    // Определяем тип ошибки для клиента
                    var error = new Error("Внутренняя ошибка сервера");
                    var statusCode = (int)HttpStatusCode.InternalServerError;
                    
                    // Настраиваем статус-код и сообщение в зависимости от типа исключения
                    if (exception is NotFoundException notFoundEx)
                    {
                        statusCode = (int)HttpStatusCode.NotFound;
                        error = new Error(notFoundEx.Message);
                    }
                    else if (exception is ValidationException validationEx)
                    {
                        statusCode = (int)HttpStatusCode.BadRequest;
                        error = new Error(validationEx.Message);
                    }
                    else if (exception is UnauthorizedAccessException)
                    {
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        error = new Error("Не авторизован");
                    }
                    
                    context.Response.StatusCode = statusCode;
                    var result = Result.Failure(error);
                    
                    await context.Response.WriteAsync(result.SerializeJson());
                }
            });
        });
    }
    
    public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (NotFoundException ex)
            {
                var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
                var path = context.Request.Path;
                var method = context.Request.Method;
                
                logger.LogWarning(ex, 
                    "Ресурс не найден при обработке запроса {Method} {Path}. TraceId: {TraceId}", 
                    method, path, traceId);
                
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                
                var error = new Error(ex.Message);
                var result = Result.Failure(error);
                
                await context.Response.WriteAsync(result.SerializeJson());
            }
            catch (ValidationException ex)
            {
                var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
                var path = context.Request.Path;
                var method = context.Request.Method;
                
                logger.LogWarning(ex, 
                    "Ошибка валидации при обработке запроса {Method} {Path}. TraceId: {TraceId}", 
                    method, path, traceId);
                
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                
                var error = new Error(ex.Message);
                var result = Result.Failure(error);
                
                await context.Response.WriteAsync(result.SerializeJson());
            }
            catch (Exception ex)
            {
                var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
                var path = context.Request.Path;
                var method = context.Request.Method;
                
                logger.LogError(ex, 
                    "Необработанное исключение при обработке запроса {Method} {Path}. TraceId: {TraceId}", 
                    method, path, traceId);
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                
                var error = new Error("Внутренняя ошибка сервера");
                var result = Result.Failure(error);

                await context.Response.WriteAsync(result.SerializeJson());
            }
        });
    }
}