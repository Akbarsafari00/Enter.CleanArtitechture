using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates.DomainEvent;

public class UserCreatedDomainEvent : DomainEventBase
{
    public UserCreatedDomainEvent(User user)
    {
        UserId = user.Id;
        Status = user.Status;
        Username = user.Username;
        Address = user.Address;
    }

    public Guid UserId { get; set; }
    public string Username { get; set; }
    public UserAddress Address { get; set; }
    public UserStatus Status { get; set; }
}