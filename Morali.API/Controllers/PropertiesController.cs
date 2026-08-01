using Morali.Application.Property.Commands.CreateProperty;
using Morali.Application.Property.Queries.GetOneProperty;
using Morali.Application.Property.Queries.ListPropertiesPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Morali.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly ISender _sender;

    public PropertiesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreatePropertyCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(new GetOneQuery(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet]
    public async Task<IActionResult> ListPaginatedAsync(
        [FromQuery] ListPropertiesPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(query, cancellationToken);
        return result.ToActionResult();
    }
}