using APIDemo.Errors;
using APIDemo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest() 
        {
            var thing = _context.products.Find(50);
            if (thing == null) 
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var thing = _context.products.Find(50);
            var thingToReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest() 
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id) 
        {
            return Ok();
        }
    }
}
