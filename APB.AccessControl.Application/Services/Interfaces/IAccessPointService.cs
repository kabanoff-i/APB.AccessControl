using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using APB.AccessControl.Shared.Models.Responses;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с проходными точками
    /// </summary>
    public interface IAccessPointService: IService<CreateAccessPointReq, UpdateAccessPointReq, int, AccessPointDto>
    {
        Task<HeartbeatResponse> UpdateHeartbeatAsync(HeartbeatReq request, CancellationToken cancellationToken = default);
    }
}
