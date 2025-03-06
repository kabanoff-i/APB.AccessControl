using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface ICardService<T, R>
    {
        R AppendCard(T card);
        R DeactivateCard();
    }
}
