using API.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.Models.Results
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public List<ErrorResult> Errors { get; set; }

        public static Result<T> MakeSuccess(T data)
        {
            return new Result<T>()
            {
                Data = data,
                Success = true,
                Errors = new List<ErrorResult>()
            };
        }

        public static Result<T> MakeFail(ValidationResult result)
        {
            var errorResults = new List<ErrorResult>();
            var errorResult = new ErrorResult(result.Field, result.Message);
                errorResults.Add(errorResult);

            return new Result<T>()
            {
                Success = false,
                Errors = errorResults
            };
        }
    }
}
