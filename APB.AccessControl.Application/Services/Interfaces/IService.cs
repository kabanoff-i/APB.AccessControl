using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    /// <summary>
    /// Базовый сервис CRUD
    /// </summary>
    /// <typeparam name="TCreate">Тип реквеста для создания</typeparam>
    /// <typeparam name="TUpdate">Тип реквеста для обновления</typeparam>
    /// <typeparam name="TDelete">Тип идентификатора для удаления</typeparam>
    /// <typeparam name="TResult">Тип возвращемого респонса</typeparam>
    public interface IService<TCreate, TUpdate, TDelete, TResult>
    {
        Task<TResult> CreateAsync(TCreate request, CancellationToken cancellationToken = default);
        Task UpdateAsync(TUpdate request, CancellationToken cancellationToken = default);
        Task DeleteAsync(TDelete id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
