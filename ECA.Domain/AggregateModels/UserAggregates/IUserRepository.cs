using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates
{
    public interface IUserRepository : IRepository<User,Guid>
    {
    }   
}
