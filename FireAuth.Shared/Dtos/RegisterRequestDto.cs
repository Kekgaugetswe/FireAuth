using System;

namespace FireAuth.Shared.Dtos;

public class RegisterRequestDto
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password {get; set;}
    public string FirebaseUid { get; set; }
}
