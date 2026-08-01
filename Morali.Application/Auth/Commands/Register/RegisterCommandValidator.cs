using FluentValidation;

namespace Morali.Application.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome deve ser fornecido")
            .OverridePropertyName("name");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail deve ser fornecido")
            .EmailAddress().WithMessage("O e-mail precisa ser válido")
            .OverridePropertyName("email");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha deve ser fornecida")
            .MinimumLength(6).WithMessage("A senha precisa ter no mínimo 6 caracteres")
            .OverridePropertyName("password");
    }
}