using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Adresses.Queries.GetCities;

public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, Result<IEnumerable<string>>>
{
    private readonly IAppDbContext _db;
    
    public GetCitiesQueryHandler(IAppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result<IEnumerable<string>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var result = await _db.Properties
            .Select(p => p.City)
            .Distinct()
            .ToArrayAsync(cancellationToken);
        
        return new Result<IEnumerable<string>>().Ok(result);
    }
}