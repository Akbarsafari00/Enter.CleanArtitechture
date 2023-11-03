using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates;

public class UserStatus : Enumeration
{
    public static UserStatus Active = new(0, nameof(Active));
    public static UserStatus DeActive = new(1, nameof(DeActive));

    public UserStatus(int id, string name) : base(id, name)
    {
    }
}