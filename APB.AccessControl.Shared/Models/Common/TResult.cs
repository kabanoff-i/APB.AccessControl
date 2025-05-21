using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{
    public class Result<T> : Result
    {
        public T Data { get; }

        public Result(bool isSuccess, List<Error> errors, T data) : base(isSuccess, errors)
        {
            Data = data;
        }
    }
}
