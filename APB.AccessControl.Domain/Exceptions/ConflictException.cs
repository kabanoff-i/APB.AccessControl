using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class ConflictException: ApplicationException
    {
        public ConflictException():base("Конфликт данных")
        { }
        public ConflictException(string message) : base(message)
        { }

        public ConflictException(string message, Exception ex) : base(message, ex)
        { }
    }
}