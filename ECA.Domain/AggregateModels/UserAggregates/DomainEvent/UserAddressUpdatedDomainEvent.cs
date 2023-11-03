using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates.DomainEvent
{
    public class UserAddressUpdatedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; set; }
        public UserAddress Address { get; set; }

        public UserAddressUpdatedDomainEvent(User user)
        {
            UserId = user.Id ;
            Address = user.Address;
        }
    }
}
