namespace APIDemo.Errors
{
    public class ApiExcepetion : ApiResponse
    {
        public ApiExcepetion(int statusCode, string message = null, string details= null) 
            : base(statusCode, message)
        {
            Details = details;
        }
        public string Details;
    }
}
