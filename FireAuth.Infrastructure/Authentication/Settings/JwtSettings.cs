using System;

namespace FireAuth.Infrastructure.Authentication.Settings;

public class JwtSettings
{
    public string  ValidIssuer { get; set; } = string.Empty;
    public string ValidAudience { get; set; } = string.Empty;

}
