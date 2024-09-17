using FireAuth.Domain.Contracts.DTOs;

namespace FireAuth.Infrastructure.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(RegisterRequestDto requestDto);
    Task<string> LoginAsync(LoginRequestDto requestDto);
}
