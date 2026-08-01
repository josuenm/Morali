using Morali.Domain.Enums;

namespace Morali.Application.Common.Responses;

public record PropertyResponse(
    Guid Id,
    PropertyType Type,
    string Title,
    string Description,
    int Bedrooms,
    int Baths,
    int ParkingSpaces,
    int EnSuites,
    string Currency,
    long RentPrice,
    long CondoFee,
    long OtherFees,
    bool AllowsPets,
    string ZipCode,
    string Number,
    string Street,
    string Neighborhood,
    string City,
    string State,
    string Uf,
    string Country,
    string CountryCode,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);