using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {


        [HttpGet("protected")]
        [Authorize]
        public IActionResult GetProtectedResource()
        {
            return Ok(new { Message = "This is a protected resource, accessible only with a valid Firebase token." });
        }

        [HttpGet("public")]
        public IActionResult GetPublicResource()
        {
            return Ok(new { Message = "This is a public resource, accessible by anyone." });
        }
    }

}
