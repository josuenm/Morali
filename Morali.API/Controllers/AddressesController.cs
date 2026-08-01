using Morali.Application.Adresses.Queries.GetCities;
using Morali.Application.Adresses.Queries.GetNeighborhood;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Morali.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly ISender _sender;
    
    public AddressesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetCitiesAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCitiesQuery(), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("neighborhood")]
    public async Task<IActionResult> GetNeighborhoodAsync(
        [FromQuery] GetNeighborhoodQuery query, 
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(query, cancellationToken);
        return result.ToActionResult();
    }
}