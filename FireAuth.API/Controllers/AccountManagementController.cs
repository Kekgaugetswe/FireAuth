using System.Security.Cryptography;
using FireAuth.Domain.Interfaces;
using FireAuth.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagementController(IAccountManagementService service) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
        {
            var result = await service.RegisterUserAsync(requestDto);
            if (result.Success)
                return Ok(result);
            return Unauthorized(result.Errors);

        }

    }
}
