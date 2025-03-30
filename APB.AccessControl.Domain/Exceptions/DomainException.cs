using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class DomainException: Exception
    {
        public DomainException():base("Ошибка уровня домена")
        { }
        public DomainException(string message) : base(message)
        { }

        public DomainException(string message, Exception ex) : base(message, ex)
        { }
    }
}