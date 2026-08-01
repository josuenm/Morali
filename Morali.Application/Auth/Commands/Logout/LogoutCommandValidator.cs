using FluentValidation;

namespace Morali.Application.Auth.Commands.Logout;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        RuleFor(command => command)
            .NotEmpty().WithMessage("O refresh token deve ser fornecido")
            .OverridePropertyName("refreshToken");
    }
}