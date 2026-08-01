using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Adresses.Queries.GetCities;

public record GetCitiesQuery() : IRequest<Result<IEnumerable<string>>>;