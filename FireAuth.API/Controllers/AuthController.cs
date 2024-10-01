using FireAuth.Domain.Contracts.DTOs;
using FireAuth.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationService service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await service.RegisterAsync(request);
            if (result == null)
            {
                return BadRequest("Registration failed");

            }

            var response = new RegisterResponseDto
            {
                Token = result
            };

            return Ok(response);

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                var token = await service.LoginAsync(loginRequest);
                return Ok(new {Token = token});
            }
            catch (Exception e)
            {
                
                return Unauthorized(e.Message);
            }

        }

    }

}

