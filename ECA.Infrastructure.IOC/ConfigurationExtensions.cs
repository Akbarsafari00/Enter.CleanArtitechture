using ECA.Application.Contracts.Services;
using ECA.Infrastructure.ExternalServices;
using ECA.Infrastructure.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddEcaConfiguration(this IServiceCollection services )
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        // Configure Core Options
        services.Configure<JwtTokenOptions>(configuration.GetSection("Jwt"));
        return services;
    }
}