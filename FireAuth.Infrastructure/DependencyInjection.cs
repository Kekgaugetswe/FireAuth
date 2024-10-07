using FireAuth.Domain.Contracts.Authentication;
using FireAuth.Domain.Contracts.Interfaces;
using FireAuth.Infrastructure.Authentication;
using FireAuth.Infrastructure.Authentication.FIrebaseProvider;
using FireAuth.Infrastructure.DataAccess;
using FireAuth.Infrastructure.Repositories;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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

            services.AddDbContext<FireAuthDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
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
        services.AddScoped(typeof(ICrudRepository<>),typeof(CrudRepository<>));

        return services;

    }

}
