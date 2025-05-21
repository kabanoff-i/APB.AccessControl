using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{
    public class Result
    {
        public Result(bool isSuccess, List<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; }
        public List<Error> Errors { get; }

        public static Result Success() => new Result(true, default);

        public static Result Failure(List<Error> errors) => new Result(false, errors);

        public static Result<T> Success<T>(T data) => new Result<T>(true, default, data);

        public static Result<T> Failure<T>(List<Error> errors) => new Result<T>(false, errors, default);
    }
}
