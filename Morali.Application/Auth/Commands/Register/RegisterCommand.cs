using Morali.Application.Common.Results;
using MediatR;

namespace Morali.Application.Auth.Commands.Register;

public record RegisterCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Result<RegisterCommandResponse>>;