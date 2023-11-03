using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Abstractions.Queries.Auth;

public record AuthProfileQuery(Guid Id) : IQuery<ServiceResult<UserDto>>;
