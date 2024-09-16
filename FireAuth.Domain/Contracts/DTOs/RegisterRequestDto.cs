using System;

namespace FireAuth.Domain.Contracts.DTOs;

public class RegisterRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }

}
