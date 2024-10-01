using FireAuth.Infrastructure.Authentication;
using FireAuth.Infrastructure.Authentication.FIrebaseProvider;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace FireAuth.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        var firebaseConfig = new FirebaseConfigProvider(configuration);
        var credentialjson = firebaseConfig.GetfirebaseCredentialsJson();
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(credentialjson.ToString())
        });
        if (environment.IsDevelopment())
        {

            services.AddHttpClient("FirebaseClient").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            });
        }
        else
        {
            services.AddHttpClient("FirebaseClient");
        }
        services.AddSingleton(FirebaseAuth.DefaultInstance);
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        JwtBearerConfiguration.ConfigureJwtBearer(services, configuration);

        return services;

    }

}
