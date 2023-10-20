using ECA.Application.Contracts.Services;
using ECA.Infrastructure.ExternalServices;
using ECA.Infrastructure.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class SecurityExtensions
{
    public static IServiceCollection AddEcaSecurityService(this IServiceCollection services )
    {
        // Add Security Services
        services.AddSingleton<IPasswordEncryptor, PasswordEncryptor>();
        services.AddSingleton<IJwtService, JwtService>();
        return services;
    }
}