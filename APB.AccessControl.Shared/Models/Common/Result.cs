using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }

        public static Result Success() => new Result(true, Error.None);

        public static Result Failure(Error error) => new Result(false, error);

        public static Result<T> Success<T>(T data) => new Result<T>(true, Error.None, data);

        public static Result<T> Failure<T>(Error error) => new Result<T>(false, error, default);
    }
}
