using Microsoft.AspNetCore.Http;

namespace MyMoneyAPI.Common
{
    public class ApiResponse<T> : ApiResponseBase
    {
        public T? Data { get; set; }          // Payload for successful responses

        // Success response constructor
        public ApiResponse(T data, int statusCode, string message = "Request completed successfully.")
        {
            Data = data;
            Success = true;
            StatusCode = statusCode;
            Message = message;
        }

        // Error response constructor
        public ApiResponse(int statusCode, string errorMessage)
        {
            Data = default;
            Success = false;
            StatusCode = statusCode;
            Message = errorMessage;
        }
    }
}
