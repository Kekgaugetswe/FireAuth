using System;
using System.Net;
using FireAuth.Domain.Contracts.Authentication;
using FireAuth.Domain.Contracts.Entities;
using FireAuth.Domain.Contracts.Interfaces;
using FireAuth.Domain.Interfaces;
using FireAuth.Shared.Dtos;
using FireAuth.Shared.Dtos.Responses;

namespace FireAuth.Domain.Services;

public class AccountManagementService(IAuthenticationService authentication, ICrudRepository<ApplicationUser> userRepository) : IAccountManagementService
{
    public Task<bool> DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto requestDto)
    {



        var firebaseUid = await authentication.RegisterAsync(requestDto);


        if (string.IsNullOrEmpty(firebaseUid))
        {
            return new RegisterResponseDto { Success = false, Errors = new List<string> { "Uer not found." } };

        }

        var user = new ApplicationUser
        {
            Email = requestDto.Email,
            FirebaseUid = firebaseUid,
            LastName = requestDto.LastName,
            FirstName = requestDto.FirstName,
            DisplayName = requestDto.DisplayName,

        };

        await userRepository.AddAsync(user);

        return new RegisterResponseDto { Success = true, FirebaseUid = firebaseUid };
    }

    public Task<bool> ResetPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }
}
