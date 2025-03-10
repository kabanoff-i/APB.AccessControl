using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IAccessPointService: IService<CreateAccessPointReq, UpdateAccessPointReq, int, AccessPointDto>
    { }
}
