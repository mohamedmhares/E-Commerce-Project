using APIDemo.Errors;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("Error/{code}")]
    [ApiController]
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
