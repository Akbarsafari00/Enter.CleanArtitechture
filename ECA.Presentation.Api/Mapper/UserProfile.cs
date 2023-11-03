using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Futures.Users.Models;
using ECA.Presentation.Api.Contracts.Auth;
using ECA.Presentation.Api.Contracts.User;
using Mapster;

namespace ECA.Presentation.Api.Mappers;

public class UserProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDto, UserResponse>()
            .Map(dest => dest, src => src);
        
        config.NewConfig<CreateUserRequest, UserCreateCommand>()
            .Map(dest => dest, src => src);
    }
}