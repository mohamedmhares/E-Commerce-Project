
namespace APIDemo.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

       

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad request , you have made",
                401 => "Authorized you are not",
                402 => "Response found it is was not",
                404 => "Server Error Occured",
                _ => null
            };
        }
    }

}