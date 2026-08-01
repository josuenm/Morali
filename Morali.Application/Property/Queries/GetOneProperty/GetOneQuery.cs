using Morali.Application.Common.Responses;
using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Property.Queries.GetOneProperty;

public record GetOneQuery(
    Guid Id
) : IRequest<Result<PropertyResponse>>;