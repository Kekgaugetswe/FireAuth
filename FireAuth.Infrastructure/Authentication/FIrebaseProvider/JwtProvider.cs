using FireAuth.Shared.Dtos;

namespace FireAuth.Infrastructure.Authentication.FIrebaseProvider;

public interface IJwtProvider
{
    Task<string> GetCredentials(LoginRequestDto requestDto);

}