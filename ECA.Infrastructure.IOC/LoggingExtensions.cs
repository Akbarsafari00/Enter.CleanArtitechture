using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class LoggingExtensions
{
    public static IServiceCollection AddEcaLogging(this IServiceCollection services )
    {
        return services;
    }
}