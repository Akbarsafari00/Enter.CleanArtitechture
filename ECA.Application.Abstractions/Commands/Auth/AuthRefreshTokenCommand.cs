using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Abstractions.Commands.Users;

public  record AuthRefreshTokenCommand(
    string AccessToken,
        string RefreshToken
    ) : ICommand<ServiceResult<AuthJwtDto>>; 
