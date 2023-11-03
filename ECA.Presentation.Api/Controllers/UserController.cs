using ECA.Application.Abstractions.Commands.Users;
using ECA.Domain.Futures.Users.Exceptions;
using ECA.Presentation.Api.Contracts.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECA.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
   
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
    {
        var command = _mapper.Map<UserCreateCommand>(request);
        await _mediator.Send(command);
        return Ok();
    }
}