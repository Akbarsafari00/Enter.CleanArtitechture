using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Abstractions.Commands.Users;

public  record AuthLoginCommand(
        string Username ,
        string Password
    ) : ICommand<ServiceResult<AuthJwtDto>>; 
