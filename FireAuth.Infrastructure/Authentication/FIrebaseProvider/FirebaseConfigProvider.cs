using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FireAuth.Infrastructure.Authentication.FIrebaseProvider;

public class FirebaseConfigProvider(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public JObject GetfirebaseCredentialsJson()
    {
        var firebaseConfig = _configuration.GetSection("Firebase");
        return new JObject
        {
                { "type", firebaseConfig["type"] },
                { "project_id", firebaseConfig["project_id"] },
                { "private_key_id", firebaseConfig["private_key_id"] },
                { "private_key", firebaseConfig["private_key"] },
                { "client_email", firebaseConfig["client_email"] },
                { "client_id", firebaseConfig["client_id"] },
                { "auth_uri", firebaseConfig["auth_uri"] },
                { "token_uri", firebaseConfig["token_uri"] },
                { "auth_provider_x509_cert_url", firebaseConfig["auth_provider_x509_cert_url"] },
                { "client_x509_cert_url", firebaseConfig["client_x509_cert_url"] }

        };
    }



}
