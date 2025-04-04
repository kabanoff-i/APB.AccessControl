using Microsoft.Extensions.DependencyInjection;
using APB.AccessControl.DataAccess.Repositories;
using APB.AccessControl.Application.Interfaces;
using System;

namespace APB.AccessControl.DataAccess.Common
{
    public static class RepositoryManager
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // Регистрация репозиториев
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccessPointRepository, AccessPointRepository>();
            services.AddScoped<IAccessGroupRepository, AccessGroupRepository>();
            services.AddScoped<IAccessRuleRepository, AccessRuleRepository>();
            services.AddScoped<IAccessLogRepository, AccessLogRepository>();
            services.AddScoped<ITriggerRepository, TriggerRepository>();
            services.AddScoped<IAccessTriggerLogRepository, AccessTriggerLogRepository>();
            services.AddScoped<IAccessPointTypeRepository, AccessPointTypeRepository>();
            services.AddScoped<IAccessGridRepository, AccessGridRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            return services;
        }
    }
}
