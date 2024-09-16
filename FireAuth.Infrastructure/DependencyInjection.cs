using FireAuth.Infrastructure.Authentication;
using FireAuth.Infrastructure.Authentication.FIrebaseProvider;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FireAuth.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var firebaseConfig = new FirebaseConfigProvider(configuration);
        var credentialjson = firebaseConfig.GetfirebaseCredentialsJson();
        FirebaseApp.Create(new AppOptions(){
            Credential = GoogleCredential.FromJson(credentialjson.ToString())
        });

        services.AddSingleton(FirebaseAuth.DefaultInstance);
        services.AddSingleton<IAuthenticationService,AuthenticationService>();

        return services;

    }

}
