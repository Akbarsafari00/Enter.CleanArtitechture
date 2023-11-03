using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates.DomainEvent
{
    public class UserUsernameUpdatedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; private set; }
        public string Username { get;private  set; }

        public UserUsernameUpdatedDomainEvent(User user)
        {
            UserId = user.Id ;
            Username = user.Username;
        }
    }
}
