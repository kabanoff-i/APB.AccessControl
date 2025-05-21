using Microsoft.Extensions.DependencyInjection;
using APB.AccessControl.Application.Services;
using APB.AccessControl.Application.Services.Interfaces;
using System;
using AutoMapper;
using System.Reflection;
using APB.AccessControl.Application.MappingProfiles;

namespace APB.AccessControl.Application.Common
{
    public static class ApplicationServicesManager
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // Регистрация сервисов приложения
            services.AddScoped<IAccessCheckService, AccessCheckService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAccessPointService, AccessPointService>();
            services.AddScoped<IAccessPointTypeService, AccessPointTypeService>();
            services.AddScoped<IAccessGroupService, AccessGroupService>();
            services.AddScoped<IAccessRuleService, AccessRuleService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITriggerService, TriggerService>();
            services.AddScoped<IAccessLogService, AccessLogService>();
            services.AddScoped<IAccessTriggerLogService, AccessTriggerLogService>();
            services.AddScoped<ICardService, CardService>();

            return services;
        }
    }
}
