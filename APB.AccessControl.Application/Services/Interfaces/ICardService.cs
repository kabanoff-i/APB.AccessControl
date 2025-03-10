using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с картами
    /// </summary>
    public interface ICardService: IService<CreateCardReq, UpdateCardReq, int, CardDto>
    { }
}
