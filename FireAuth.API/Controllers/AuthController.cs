using FireAuth.Domain.Contracts.Authentication;
using FireAuth.Shared.Dtos;
using FireAuth.Shared.Dtos.Responses;
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
                Success= true
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
            catch (Exception ex)
            {
                
                return Unauthorized(ex.Message);
            }

        }

    }

}

