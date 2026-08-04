using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Property.Queries.GetOneProperty;

public class GetOneQueryHandler : IRequestHandler<GetOneQuery, Result<PropertyResponse>>
{
    private readonly IAppDbContext _db;

    public GetOneQueryHandler(IAppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result<PropertyResponse>> Handle(
        GetOneQuery request, 
        CancellationToken cancellationToken
    )
    {
        var property = await _db.Properties
            .AsNoTracking()    
            .FirstOrDefaultAsync(
                p => p.Id == request.Id, 
                cancellationToken
            );

        if (property == null) return new Result<PropertyResponse>()
            .NotFound("Propriedade não encontrada");

        return new Result<PropertyResponse>().Ok(new (
            property.Id,
            property.Type,
            property.Title,
            property.Description,
            property.Bedrooms,
            property.Baths,
            property.ParkingSpaces,
            property.EnSuites,
            property.Currency,
            property.RentPrice,
            property.CondoFee,
            property.OtherFees,
            property.AllowsPets,
            property.ZipCode,
            property.Number,
            property.Street,
            property.Neighborhood,
            property.City,
            property.State,
            property.Uf,
            property.Country,
            property.CountryCode,
            property.CreatedAt,
            property.UpdatedAt
        ));
    }
}