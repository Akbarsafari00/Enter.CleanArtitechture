using ECA.Application.Abstractions.Repositories;
using ECA.Infrastructure.DataAccess.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services )
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}