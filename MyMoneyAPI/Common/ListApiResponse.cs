namespace MyMoneyAPI.Common
{
    public class ListApiResponse<T> : ApiResponseBase
    {
        public List<T> Data { get; set; }  // List response

        public ListApiResponse(List<T> data, int statusCode, string message = "Request completed successfully.")
        {
            Data = data;
            Success = true;
            StatusCode = statusCode;
            Message = message;
        }

        public ListApiResponse(int statusCode, string error)
        {
            Data = null;  // Assign null for list
            Success = false;
            StatusCode = statusCode;
            Message = "Request failed.";
        }
    }
}
