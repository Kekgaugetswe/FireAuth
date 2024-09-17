using System;
using FireAuth.Domain.Contracts.DTOs;

namespace FireAuth.Infrastructure.Authentication.FIrebaseProvider;

public interface IJwtProvider
{
    Task<string> GetCredentials(LoginRequestDto requestDto);

}
