using ECA.Application.Contracts.Services;
using ECA.Infrastructure.ExternalServices;
using ECA.Infrastructure.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class ExternalServiceExtensions
{
    public static IServiceCollection AddEcaExternalService(this IServiceCollection services )
    {
     
        
        return services;
    }
}