using ECA.Application.Abstractions.Repositories;
using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckFieldExists<TProp>(Func<User, TProp> func, TProp prop, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}