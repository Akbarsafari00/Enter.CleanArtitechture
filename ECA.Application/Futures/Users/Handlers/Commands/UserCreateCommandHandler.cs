using AutoMapper;
using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Abstractions.Repositories;
using ECA.Application.Abstractions.Services.Security;
using ECA.Application.Core;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;
using MediatR;

namespace ECA.Application.Futures.Users.Handlers.Commands;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand,ServiceResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncryptor _passwordEncryptor;
    public UserCreateCommandHandler(IUserRepository userRepository, IPasswordEncryptor passwordEncryptor, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordEncryptor = passwordEncryptor;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var checkUsername = await _userRepository.CheckFieldExists(x => x.UserName, request.UserName,cancellationToken);

        if (checkUsername)
        {
            throw new Exception("user with this username already exists");
        }

        var password = _passwordEncryptor.Encrypt(request.Password);
        var user = new User(request.UserName,password,request.Address,UserStatus.Active);
        await _userRepository.CreateAsync(user, cancellationToken);

        var dto = _mapper.Map<UserDto>(user);

        return new ServiceResult<UserDto>(dto);
    }
}