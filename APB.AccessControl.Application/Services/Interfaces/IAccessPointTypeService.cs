using APB.AccessControl.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с типами точек доступа
    /// </summary>
    public interface IAccessPointTypeService
    {
        /// <summary>
        /// Получить все типы точек доступа
        /// </summary>
        Task<IEnumerable<AccessPointTypeDto>> GetAllAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить тип точки доступа по идентификатору
        /// </summary>
        Task<AccessPointTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
} 