using System.Net.Http.Json;
using FireAuth.Domain.Contracts.DTOs;
using FireAuth.Domain.Contracts.DTOs.Responses;
using FirebaseAdmin.Auth;
using Microsoft.Extensions.Configuration;

namespace FireAuth.Infrastructure.Authentication;

public class AuthenticationService(IConfiguration configuration, HttpClient httpClient) : IAuthenticationService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> LoginAsync(LoginRequestDto requestDto)
    {
        var firebaseApiKey = _configuration["Authentic:apiKey"];

        var loginRequest = new
        { 
            email = requestDto.Email,
            password = requestDto.Password,
            returnSecureToken = true
        };
        var response = await _httpClient.PostAsJsonAsync(firebaseApiKey, loginRequest);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<FirebaseLoginResponse>();

            
            return result.IdToken;
        }

        return string.Empty;
    }
    

    public async Task<string> RegisterAsync(RegisterRequestDto requestDto)
    {
        var userArgs = new UserRecordArgs
        {
            Email = requestDto.Email,
            Password = requestDto.Password,
        };

        var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
        return userRecord.Uid;
    }
}
