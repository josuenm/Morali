using FluentValidation;

namespace Morali.Application.Property.Commands.CreateProperty;

public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
{
    public CreatePropertyCommandValidator()
    {
        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("O tipo deve ser fornecido")
            .OverridePropertyName("type");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título deve ser fornecido")
            .OverridePropertyName("title");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição deve ser fornecida")
            .OverridePropertyName("description");

        RuleFor(x => x.Bedrooms)
            .NotNull().WithMessage("O quarto deve ser fornecido")
            .OverridePropertyName("bedrooms");
        
        RuleFor(x => x.Baths)
            .NotNull().WithMessage("O banheiro deve ser fornecido")
            .OverridePropertyName("baths");
        
        RuleFor(x => x.ParkingSpaces)
            .NotNull().WithMessage("A vaga de garagem deve ser fornecida")
            .OverridePropertyName("parkingSpaces");
        
        RuleFor(x => x.EnSuites)
            .NotNull().WithMessage("A suíte deve ser fornecida")
            .OverridePropertyName("enSuites");
        
        RuleFor(x => x.Currency)
            .NotEmpty().WithMessage("A moeda deve ser fornecida")
            .OverridePropertyName("currency");
        
        RuleFor(x => x.RentPrice)
            .NotEmpty().WithMessage("O valor do aluguel deve ser fornecido")
            .OverridePropertyName("rentPrice");

        RuleFor(x => x.CondoFee)
            .NotNull().WithMessage("O valor do condominio deve ser fornecido")
            .OverridePropertyName("condoFee");
        
        RuleFor(x => x.OtherFees)
            .NotNull().WithMessage("As outras taxas devem ser fornecidas")
            .OverridePropertyName("otherFees");

        RuleFor(x => x.AllowsPets)
            .NotEmpty().WithMessage("A permissão de pet deve ser fornecida");
        
        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("CEP é obrigatório.")
            .Length(8).WithMessage("CEP deve conter 8 dígitos.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Número é obrigatório.")
            .MaximumLength(20);

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Rua é obrigatória.")
            .MaximumLength(200);

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("Bairro é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Cidade é obrigatória.")
            .MaximumLength(100);

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("Estado é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.Uf)
            .NotEmpty().WithMessage("UF é obrigatória.")
            .Length(2).WithMessage("UF deve conter 2 caracteres.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("País é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.CountryCode)
            .NotEmpty().WithMessage("Código do país é obrigatório.")
            .Length(2).WithMessage("Código do país deve conter 2 caracteres.");
    }
}