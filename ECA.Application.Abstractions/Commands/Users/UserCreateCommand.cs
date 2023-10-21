using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using MediatR;

namespace ECA.Application.Abstractions.Commands.Users;

public record UserCreateCommand(
        string UserName ,
        string Password,
        string FirstName,
        string Lastname,
        UserAddress Address
    ) : IRequest<ServiceResult<UserDto>>; 
