using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhisperingPages.Api.Features.Users.Commands;

namespace WhisperingPages.Api.Api.Controllers;

public class UserController(IMediator mediator) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserCommand command)
    {
        var result = await mediator.Send(command);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
