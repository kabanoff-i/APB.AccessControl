using System;
using System.Linq.Expressions;

namespace APB.AccessControl.Shared.Models.Common
{
    public abstract class BaseFilter<T> : IFilter<T>
    {
        public abstract Expression<Func<T, bool>> GetExpression();
    }
}
