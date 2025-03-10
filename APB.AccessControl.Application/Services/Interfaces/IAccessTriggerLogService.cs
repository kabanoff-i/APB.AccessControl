using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с логами выполнения триггеров
    /// </summary>
    public interface IAccessTriggerLogService
    {
        Task LogAccessTriggerExecutionAsync(CreateAccessLogReq request, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessTriggerLogDto>> GetAll(CancellationToken cancellationToken = default);
    }
}