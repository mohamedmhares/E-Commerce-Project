using APIDemo.Errors;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace APIDemo.Middleware
{
    public class ExcepetionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcepetionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExcepetionMiddleware(IHostEnvironment environment, ILogger<ExcepetionMiddleware> logger, RequestDelegate next)
        {

            _logger = logger;
            _environment = environment;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _environment.IsDevelopment()
                    ? new ApiExcepetion((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiExcepetion((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
