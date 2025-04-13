using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using APB.AccessControl.Domain.Exceptions;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared;

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
                    logger.LogError($"Непредвиденная ошибка: {contextFeature.Error}");

                    var error = new Error("Внутренняя ошибка сервера");
                    
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
                logger.LogWarning($"Ресурс не найден: {ex}");
                
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                
                var error = new Error(ex.Message);
                var result = Result.Failure(error);
                
                await context.Response.WriteAsync(result.SerializeJson());
            }
            catch (Exception ex)
            {
                logger.LogError($"Необработанное исключение: {ex}");
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                
                var error = new Error("Внутренняя ошибка сервера");
                var result = Result.Failure(error);

                await context.Response.WriteAsync(result.SerializeJson());
            }
        });
    }
}