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
        private readonly IAuthenticationService _service = service;

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.RegisterAsync(request);
            if (result == null)
            {
                return BadRequest("Registration failed");

            }

            var response = new RegisterResponseDto
            {
                Token= result
            };

            return Ok(response);

        }

    }

}

