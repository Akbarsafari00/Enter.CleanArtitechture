
using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        public Task CreateAsync(User user , CancellationToken cancellationToken = default);
        Task<bool> CheckFieldExists<TProp>(Func<User, TProp> func, TProp prop, CancellationToken cancellationToken = default);
    }   
}
