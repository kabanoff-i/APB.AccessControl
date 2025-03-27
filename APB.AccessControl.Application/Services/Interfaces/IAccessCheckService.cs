using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IAccessCheckService
    {
        Task<AccessCheckResponse> CheckAccessAsync(CheckAccessReq request, CancellationToken cancellationToken = default);
    }
}
