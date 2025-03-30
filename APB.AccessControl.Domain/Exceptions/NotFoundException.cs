using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, Exception ex) : base(message, ex)
        { }
        public NotFoundException(string name, string field, object value)
        : base($"Объект \"{name}\" с ключом {field} = {value} не найден.")
        {
        }
    }
}