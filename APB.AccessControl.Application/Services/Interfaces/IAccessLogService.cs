using APB.AccessControl.Application.Filters;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IAccessLogService: IService<>
    {
        Task<IEnumerable> GetLogsByFilterAsync(AccessLogFilter filter = default, CancellationToken cancellationToken = default);
    }
}
