using ECA.Application.Abstractions.Commands.Users;
using ECA.Application.Abstractions.Queries.Auth;
using ECA.Application.Futures.Users.Models;
using ECA.Common.Extensions;
using ECA.Domain.Futures.Users.Exceptions;
using ECA.Presentation.Api.Contracts.Auth;
using ECA.Presentation.Api.Contracts.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECA.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
   
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AuthController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("Profile")]
    public async Task<ActionResult<UserDto>> Profile()
    {
    
        var result= await _mediator.Send(new AuthProfileQuery(User.GetUserId()));
        var response = _mapper.Map<UserResponse>(result.Result!);
        return Ok(response);
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<AuthJwtResponse>> Login([FromBody] AuthLoginRequest request)
    {
        var command = _mapper.Map<AuthLoginCommand>(request);
        var result= await _mediator.Send(command);
        var response = _mapper.Map<AuthJwtResponse>(result.Result!);
        return Ok(response);
    }
    
    [HttpPost("Refresh")]
    public async Task<ActionResult<AuthJwtResponse>> Refresh([FromBody] AuthRefreshTokenRequest request)
    {
        var command = _mapper.Map<AuthRefreshTokenCommand>(request);
        var result= await _mediator.Send(command);
        var response = _mapper.Map<AuthJwtResponse>(result.Result!);
        return Ok(response);
    }
}