
using FireAuth.Shared.Dtos;

namespace FireAuth.Domain.Contracts.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(RegisterRequestDto requestDto);
    Task<string> LoginAsync(LoginRequestDto requestDto);
}
