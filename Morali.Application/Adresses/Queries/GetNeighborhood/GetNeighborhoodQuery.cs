using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Adresses.Queries.GetNeighborhood;

public record GetNeighborhoodQuery(string city) : IRequest<Result<IEnumerable<string>>>;