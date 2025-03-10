using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с проходными точками
    /// </summary>
    public interface IAccessPointService: IService<CreateAccessPointReq, UpdateAccessPointReq, int, AccessPointDto>
    { }
}
