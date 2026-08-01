using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<Result<RefreshTokenCommandResponse>>;