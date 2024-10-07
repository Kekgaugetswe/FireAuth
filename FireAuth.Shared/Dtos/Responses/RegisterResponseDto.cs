using System;

namespace FireAuth.Shared.Dtos.Responses;

public class RegisterResponseDto
{
    public bool Success { get; set; }  

    public List<string> Errors { get; set; } = new List<string>();  

    public string FirebaseUid { get; set; }
}
