using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException():base()
        {  }
        public ApplicationException(string message) : base(message)
        {  }

        public ApplicationException(string message, Exception ex) : base(message, ex)
        {  }
    }
}

