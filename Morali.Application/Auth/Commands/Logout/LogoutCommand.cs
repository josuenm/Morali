using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Auth.Commands.Logout;

public record LogoutCommand(string? RefreshToken) : IRequest<Result<LogoutCommandResponse>>;