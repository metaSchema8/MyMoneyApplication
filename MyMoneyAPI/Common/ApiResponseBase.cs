namespace MyMoneyAPI.Common
{
    public abstract class ApiResponseBase
    {
        public bool Success { get; set; }    // Indicates if the request was successful
        public int StatusCode { get; set; } // HTTP status code
        public string Message { get; set; }  // Success or error message
    }
}
