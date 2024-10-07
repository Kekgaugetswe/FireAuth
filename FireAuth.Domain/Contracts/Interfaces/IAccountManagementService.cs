using FireAuth.Shared.Dtos;
using FireAuth.Shared.Dtos.Responses;


namespace FireAuth.Domain.Interfaces;

public interface IAccountManagementService
{
    Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto request);
    Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request);
    Task<bool> ResetPasswordAsync(string email);
    Task<bool> DeleteUserAsync(int userId);

}
