using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с триггерами
    /// </summary>
    public interface ITriggerService : IService<CreateTriggerReq, UpdateTriggerReq, int, TriggerDto>
    {
        Task ExecuteTriggersAsync(Guid accessLogId, CancellationToken cancellationToken = default);
    }
}