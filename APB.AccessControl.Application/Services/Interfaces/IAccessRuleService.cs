using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using APB.AccessControl.Shared.Models.Filters;
namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с правилами прохода
    /// </summary>
    public interface IAccessRuleService: IService<CreateAccessRuleReq, UpdateAccessRuleReq, int, AccessRuleDto>
    {
        Task<IEnumerable<AccessRuleDto>> GetByFilterAsync(AccessRuleFilterDto filter = default, CancellationToken cancellationToken = default);
    }
}