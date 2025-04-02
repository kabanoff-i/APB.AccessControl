using APB.AccessControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace APB.AccessControl.Application.Interfaces
{
    public interface ICardRepository: IRepository<Card, int>
    {
        Task<Card> GetByHashAsync(string hash, CancellationToken cancellationToken = default);
        Task<IEnumerable<Card>> GetAllByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
