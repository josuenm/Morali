using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Auth.Queries.Me;

public record MeQuery : IRequest<Result<MeQueryResponse>>;