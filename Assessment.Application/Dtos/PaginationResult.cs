using Assessment.Application.Constants;

namespace Assessment.Application.Dtos
{
    public class PaginationResult<T>
    {
        private PaginationResult(T data, int totalCount, int totalPages)
        {
            Data = data;
            ResponseMessage = ResponseMessages.OperationSuccessful;
            ResponseCode = StatusCode.OperationSuccessful;
            TotalCount = totalCount;
            TotalPages = totalPages;
            IsSuccessful = true;
        }
        private PaginationResult(string statusCode = null, string message = null)
        {
            ResponseMessage = string.IsNullOrEmpty(message) ? ResponseMessages.OperationFailed : message;
            ResponseCode = string.IsNullOrEmpty(statusCode) ? StatusCode.OperationFailed : statusCode;
        }
        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public static PaginationResult<T> Success(T data, int totalPages, int totalCount) => new PaginationResult<T>(data, totalCount, totalPages);
        public static PaginationResult<T> Failed(string statusCode, string messages) => new PaginationResult<T>(statusCode, messages);

    }
}
