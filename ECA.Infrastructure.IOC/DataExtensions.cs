using ECA.Application.Abstractions.Repositories;
using ECA.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.IoC;

public static class DataExtensions
{
    public static IServiceCollection AddEcaDataAccess(this IServiceCollection services )
    {

        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}