using APB.AccessControl.Application.Filters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с логами проходов
    /// </summary>
    public interface IAccessLogService
    {
        Task LogAccessAttemptAsync(CreateAccessLogReq request, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccessLogDto>> GetLogsByFilterAsync(AccessLogFilter filter = default, CancellationToken cancellationToken = default);
    }
}
