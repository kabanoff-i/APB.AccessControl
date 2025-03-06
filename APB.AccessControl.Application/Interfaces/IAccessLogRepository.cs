using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace APB.AccessControl.Application.Interfaces
{
    public interface IAccessLogRepository : IRepository<AccessLog, Guid>
    { }
}
