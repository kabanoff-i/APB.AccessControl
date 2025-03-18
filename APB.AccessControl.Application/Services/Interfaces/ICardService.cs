using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с картами
    /// </summary>
    public interface ICardService: IService<CreateCardReq, UpdateCardReq, int, CardDto>
    {
        Task<IEnumerable<CardDto>> GetCardsByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
