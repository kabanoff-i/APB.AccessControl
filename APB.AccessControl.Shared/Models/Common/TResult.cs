using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{
    public class Result<T> : Result
    {
        public T Data { get; }

        public Result(bool isSuccess, Error error, T data) : base(isSuccess, error)
        {
            Data = data;
        }
    }
}
