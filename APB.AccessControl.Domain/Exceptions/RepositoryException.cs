using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class RepositoryException : Exception
    {
        public string MethodName { get; }
        public object[] Parameters { get; }

        public RepositoryException(string methodName, params object[] parameters) 
            : base("Ошибка выполнения операции в репозитории")
        {
            MethodName = methodName;
            Parameters = parameters;
        }

        public RepositoryException(Exception innerException, string methodName, params object[] parameters)
            : base("Ошибка выполнения операции в репозитории", innerException)
        {
            MethodName = methodName; 
            Parameters = parameters;
        }
    }
}