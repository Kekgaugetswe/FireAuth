using FireAuth.Infrastructure.Authentication;
using FireAuth.Infrastructure.Authentication.FIrebaseProvider;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FireAuth.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var firebaseConfig = new FirebaseConfigProvider(configuration);
        var credentialjson = firebaseConfig.GetfirebaseCredentialsJson();
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(credentialjson.ToString())
        });

        services.AddSingleton(FirebaseAuth.DefaultInstance);
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["Jwt:Firebase:ValidIssuer"];
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Firebase:ValidIssuer"],
                ValidAudience = configuration["Jwt:Firebase:ValidAudience"]
            };

        });

        return services;

    }

}
