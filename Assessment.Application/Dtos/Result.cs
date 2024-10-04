using Assessment.Application.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Dtos
{
    public class Result<T>
    {
        private Result(T data, string statusCode = null, string message = null)
        {
            Data = data;
            ResponseMessage = string.IsNullOrEmpty(message) ? ResponseMessages.OperationSuccessful : message;
            ResponseCode = string.IsNullOrEmpty(statusCode) ? StatusCode.OperationSuccessful : statusCode;
            IsSuccessful = true;
        }
        private Result(string statusCode = null, string message = null)
        {
            ResponseMessage = string.IsNullOrEmpty(message) ? ResponseMessages.OperationFailed : message;
            ResponseCode = string.IsNullOrEmpty(statusCode) ? StatusCode.OperationFailed : statusCode;
        }
        private Result(List<Error> errors)
        {
            ResponseMessage = ResponseMessages.ValidationFailed;
            ResponseCode = StatusCode.OperationFailed;
            Errors = errors;
        }
        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public List<Error> Errors { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public static Result<T> Success(T data) => new Result<T>(data);
        public static Result<T> Failed(string statusCode, string messages) => new Result<T>(statusCode, messages);
        public static Result<T> Failed(List<Error> errors) => new Result<T>(errors);

    }   
}
