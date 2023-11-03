using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Abstractions.Services.Security;
using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using ECA.Domain.Futures.Users.Exceptions;
using MapsterMapper;
using Optimum.SharedKernel.CQRS;

namespace ECA.Application.Futures.Users.Handlers.Commands;

public class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, ServiceResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserCreateCommandHandler(IUserRepository userRepository, 
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var checkUsername = await _userRepository.AnyAsync(x => x.Username == request.UserName, cancellationToken);

        if (checkUsername) throw new UserAlreadyExistsException(request.UserName);

        var user = new User(request.UserName, request.Password, request.FirstName,request.Lastname,request.Address, UserStatus.Active);
        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<UserDto>(user);
        return new ServiceResult<UserDto>(dto);
    }
}