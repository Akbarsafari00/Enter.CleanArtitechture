using ECA.Domain.AggregateModels.UserAggregates;
using ECA.Infrastructure.DataAccess;
using ECA.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Domain;

public static class InfrastructureDataAccessModule
{
    public static IServiceCollection AddInfrastructureDataAccessModule(this IServiceCollection services , string connectionString)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(connectionString);
        });

        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}