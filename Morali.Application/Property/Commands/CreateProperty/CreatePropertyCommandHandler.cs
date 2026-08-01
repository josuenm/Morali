using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using MediatR;
using PropertyEntity = Morali.Domain.Entities.Property;

namespace Morali.Application.Property.Commands.CreateProperty;

public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Result<PropertyResponse>>
{
    private readonly IAppDbContext _db;
    private readonly ICurrentUserService _currentUserService;

    public CreatePropertyCommandHandler(ICurrentUserService currentUserService, IAppDbContext db)
    {
        _db = db;
        _currentUserService = currentUserService;
    }
    
    public async Task<Result<PropertyResponse>> Handle(
        CreatePropertyCommand request, 
        CancellationToken cancellationToken
    )
    {
        var userId = _currentUserService.UserId;
        if (userId is null) return new Result<PropertyResponse>().Unauthorized("Acesso negado");

        var entity = PropertyEntity.Create(
            request.Type,
            request.Title,
            request.Description,
            request.Bedrooms,
            request.Baths,
            request.ParkingSpaces,
            request.EnSuites,
            request.Currency,
            request.RentPrice,
            request.CondoFee,
            request.OtherFees,
            request.RentPrice + request.CondoFee + request.OtherFees,
            userId.Value,
            request.AllowsPets,
            request.ZipCode,
            request.Number,
            request.Street,
            request.Neighborhood,
            request.City,
            request.State,
            request.Uf,
            request.Country,
            request.CountryCode
        );

        _db.Properties.Add(entity);
        await _db.SaveChangesAsync(cancellationToken);

        return new Result<PropertyResponse>().Ok(new(
            entity.Id,
            entity.Type,
            entity.Title,
            entity.Description,
            entity.Bedrooms,
            entity.Baths,
            entity.ParkingSpaces,
            entity.EnSuites,
            entity.Currency,
            entity.RentPrice,
            entity.CondoFee,
            entity.OtherFees,
            entity.AllowsPets,
            entity.ZipCode,
            entity.Number,
            entity.Street,
            entity.Neighborhood,
            entity.City,
            entity.State,
            entity.Uf,
            entity.Country,
            entity.CountryCode,
            entity.CreatedAt,
            entity.UpdatedAt
        ));
    }
}