using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using Morali.Domain.Enums;
using MediatR;

namespace Morali.Application.Property.Commands.CreateProperty;

public record CreatePropertyCommand(
    PropertyType Type,
    string Title,
    string Description,
    string Currency,
    long RentPrice,
    long CondoFee,
    long OtherFees,
    int Bedrooms,
    int Baths,
    int ParkingSpaces,
    int EnSuites,
    bool AllowsPets,
    string ZipCode,
    string Number,
    string Street,
    string Neighborhood,
    string City,
    string State,
    string Uf,
    string Country,
    string CountryCode
) : IRequest<Result<PropertyResponse>>;