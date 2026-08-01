using FluentValidation;

namespace Morali.Application.Auth.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(command => command)
            .NotEmpty().WithMessage("O refresh token deve ser fornecido")
            .OverridePropertyName("refreshToken");
    }
}