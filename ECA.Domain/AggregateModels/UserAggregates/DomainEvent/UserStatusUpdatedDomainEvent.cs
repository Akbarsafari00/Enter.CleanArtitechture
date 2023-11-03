using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates.DomainEvent
{
    public class UserStatusUpdatedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; set; }
        public UserStatus Status { get; set; }

        public UserStatusUpdatedDomainEvent(User user)
        {
            UserId = user.Id ;
            Status = user.Status;
        }
    }
}
