using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using Mapster;

namespace ECA.Application.Futures.Users.Mappers;

public class UserProfile : IRegister
{
 
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserAddress, UserAddressDto>();

        config.NewConfig<User, UserDto>()
            .Map(x => x.Status, x => x.Status.Name)
            .Map(x => x.StatusId, x => x.Status.Id);
    }
}