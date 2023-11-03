using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Abstractions.Commands.Users;

public  record UserCreateCommand(
        string UserName ,
        string Password,
        string FirstName,
        string Lastname,
        UserAddress Address
    ) : ICommand<ServiceResult<UserDto>>; 
