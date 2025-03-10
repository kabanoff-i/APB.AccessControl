using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IService<TCreate, TUpdate, TDelete, TResult>
    {
        Task<TResult> CreateAsync(TCreate request, CancellationToken cancellationToken = default);
        Task UpdateAsync(TUpdate request, CancellationToken cancellationToken = default);
        Task DeleteAsync(TDelete id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
