using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Auth.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<LoginCommandResponse>>;