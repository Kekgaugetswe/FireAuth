using FireAuth.Domain.Contracts.DTOs;
using FirebaseAdmin.Auth;

namespace FireAuth.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public Task<string> LoginAsync(LoginRequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string> RegisterAsync(RegisterRequestDto requestDto)
    {
        var userArgs = new UserRecordArgs
        {
            Email = requestDto.Email,
            Password = requestDto.Password,
        };

       var userRecord = await  FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
       return userRecord.Uid;
    }
}
