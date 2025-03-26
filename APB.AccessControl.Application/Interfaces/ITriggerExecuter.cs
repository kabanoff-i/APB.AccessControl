using APB.AccessControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APB.AccessControl.Application.Interfaces
{
    public interface ITriggerExecuter
    {
        Task ExecuteAsync(Trigger trigger, CancellationToken cancellationToken = default);
    }
}
