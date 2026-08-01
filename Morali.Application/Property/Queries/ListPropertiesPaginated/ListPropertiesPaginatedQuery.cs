using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using Morali.Domain.Enums;
using MediatR;

namespace Morali.Application.Property.Queries.ListPropertiesPaginated;

public record ListPropertiesPaginatedQuery(
    int Page,
    string City,
    PropertyType? Type,
    string? Search,
    int? Bedrooms,
    int? Baths,
    int? ParkingSpaces,
    int? EnSuites,
    long? RentPriceFrom,
    long? RentPriceTo,
    bool? TotalPrice,
    int? Limit = 10
) : IRequest<Result<PaginatedResponse<PropertyResponse>>>;