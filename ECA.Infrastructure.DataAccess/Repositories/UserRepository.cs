using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Infrastructure.DataAccess.Repositories;

public class UserRepository :RepositoryBase<User,Guid>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}