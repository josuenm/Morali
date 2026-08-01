using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Property.Queries.ListPropertiesPaginated;

public class ListPropertiesPaginatedQueryHandler 
    : IRequestHandler<ListPropertiesPaginatedQuery, Result<PaginatedResponse<PropertyResponse>>>
{
    private readonly IAppDbContext _db;

    public ListPropertiesPaginatedQueryHandler(IAppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result<PaginatedResponse<PropertyResponse>>> Handle(
        ListPropertiesPaginatedQuery request, 
        CancellationToken cancellationToken
    )
    {
        var query = _db.Properties.AsNoTracking().AsQueryable();
        
        query = query.Where(p => p.City == request.City);

        if (request.Type is not null)
            query = query.Where(p => p.Type == request.Type);

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(p =>
                EF.Functions.Like(p.Title, $"%{request.Search}%") ||
                EF.Functions.Like(p.Description, $"%{request.Search}%")
            );
        
        if (request.Bedrooms is not null)
            query = query.Where(p => p.Bedrooms >= request.Bedrooms);
        
        if (request.Baths is not null)
            query = query.Where(p => p.Baths >= request.Baths);
        
        if (request.ParkingSpaces is not null)
            query = query.Where(p => p.ParkingSpaces >= request.ParkingSpaces);
        
        if (request.EnSuites is not null)
            query = query.Where(p => p.EnSuites >= request.EnSuites);

        if (request.TotalPrice == true)
        {
            if (request.RentPriceFrom is not null)
                query = query.Where(p => p.TotalPrice >= request.RentPriceFrom);

            if (request.RentPriceTo is not null)
                query = query.Where(p => p.TotalPrice <= request.RentPriceTo);
        }
        else
        {
            if (request.RentPriceFrom is not null)
                query = query.Where(p => p.RentPrice >= request.RentPriceFrom);

            if (request.RentPriceTo is not null)
                query = query.Where(p => p.RentPrice <= request.RentPriceTo);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        var limit = request.Limit ?? 10;

        var items = await query
            .Skip((request.Page - 1) * limit)
            .Take(limit)
            .Select(p => new PropertyResponse(
                p.Id,
                p.Type,
                p.Title,
                p.Description,
                p.Bedrooms,
                p.Baths,
                p.ParkingSpaces,
                p.EnSuites,
                p.Currency,
                p.RentPrice,
                p.CondoFee,
                p.OtherFees,
                p.AllowsPets,
                p.ZipCode,
                p.Number,
                p.Street,
                p.Neighborhood,
                p.City,
                p.State,
                p.Uf,
                p.Country,
                p.CountryCode,
                p.CreatedAt,
                p.UpdatedAt
            ))
            .ToListAsync(cancellationToken);
        
        return new Result<PaginatedResponse<PropertyResponse>>().Ok(new (
            items,
            request.Page,
            limit,
            (int)Math.Ceiling((double)totalCount / limit),
            totalCount
        ));
    }
}