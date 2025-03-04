using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IService<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> Get(T entity);
        Task<IEnumerable<T>> GetAll();

    }
}
