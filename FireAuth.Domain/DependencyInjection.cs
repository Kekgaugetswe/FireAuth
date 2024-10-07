using System;
using FireAuth.Domain.Interfaces;
using FireAuth.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FireAuth.Domain;

public static class DependencyInjection
{

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {

        services.AddTransient<IAccountManagementService, AccountManagementService>();

        
        return services;

    }

}
