using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Futures.Users.Models;
using ECA.Presentation.Api.Contracts.Auth;
using ECA.Presentation.Api.Contracts.User;
using Mapster;

namespace ECA.Presentation.Api.Mappers;

public class AuthProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthLoginRequest, AuthLoginCommand>()
            .Map(dest => dest, src => src);
        
        config.NewConfig<AuthRefreshTokenRequest, AuthRefreshTokenCommand>()
            .Map(dest => dest, src => src);
        
        config.NewConfig<AuthJwtDto, AuthJwtResponse>()
            .Map(dest => dest.User, src => src.User)
            .Map(dest => dest, src => src);
    }
}