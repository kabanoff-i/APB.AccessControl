using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> GetExpression();
    }
}
