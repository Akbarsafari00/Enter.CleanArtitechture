using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Abstractions.Queries.Auth;
using ECA.Application.Abstractions.Services.Security;
using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using ECA.Domain.Futures.Users.Exceptions;
using MapsterMapper;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Futures.Users.Handlers.Commands;

public class AuthProfileQuerydHandler : IQueryHandler<AuthProfileQuery, ServiceResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public AuthProfileQuerydHandler(IUserRepository userRepository, 
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(AuthProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindById(request.Id, cancellationToken);

        if (user == null) throw new UserNotFoundException(request.Id);

        var userDto = _mapper.Map<UserDto>(user);
        return new ServiceResult<UserDto>(userDto);
    }
}