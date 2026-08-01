using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Adresses.Queries.GetNeighborhood;

public class GetNeighborhoodQueryHandler : IRequestHandler<GetNeighborhoodQuery, Result<IEnumerable<string>>>
{
    private readonly IAppDbContext _db;

    public GetNeighborhoodQueryHandler(IAppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result<IEnumerable<string>>> Handle(
        GetNeighborhoodQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _db.Properties
            .Where(p => p.City == request.city)
            .Select(p => p.Neighborhood)
            .Distinct()
            .ToArrayAsync(cancellationToken);

        return new Result<IEnumerable<string>>().Ok(result);
    }
}