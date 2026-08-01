using Morali.Application.Auth.Commands.Login;
using Morali.Application.Auth.Commands.Logout;
using Morali.Application.Auth.Commands.RefreshToken;
using Morali.Application.Auth.Commands.Register;
using Morali.Application.Auth.Queries.Me;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Morali.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginCommand command, 
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(command, cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterCommand command, 
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMeAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new MeQuery(), cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> LogoutAsync(
        [FromBody] LogoutCommand command,  
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync(
        [FromBody] RefreshTokenCommand command,  
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(command, cancellationToken);
        return result.ToActionResult();
    }
}