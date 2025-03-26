using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с логами выполнения триггеров
    /// </summary>
    public interface IAccessTriggerLogService
    {
        Task LogAccessTriggerExecutionAsync(CreateAccessTriggerLogReq request, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessTriggerLogDto>> GetAll(CancellationToken cancellationToken = default);
    }
}