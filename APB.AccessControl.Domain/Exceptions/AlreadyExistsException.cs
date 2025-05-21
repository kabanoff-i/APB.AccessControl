using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Domain.Exceptions
{
    public class AlreadyExistsException: ApplicationException
    {
        public AlreadyExistsException(string entityName, string propertyName, object propertyValue)
            : base($"Объект '{entityName}' с свойством '{propertyName}' = '{propertyValue}' уже существует.")
        {
        }
        public AlreadyExistsException(string message) : base(message)
        {
        }
        public AlreadyExistsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
