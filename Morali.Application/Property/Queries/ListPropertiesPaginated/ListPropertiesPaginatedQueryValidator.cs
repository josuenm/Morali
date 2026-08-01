using FluentValidation;

namespace Morali.Application.Property.Queries.ListPropertiesPaginated;

public class ListPropertiesPaginatedQueryValidator : AbstractValidator<ListPropertiesPaginatedQuery>
{
    public ListPropertiesPaginatedQueryValidator()
    {
        RuleFor(q => q.Page)
            .GreaterThan(0).WithMessage("A página deve ser maior que 0")
            .OverridePropertyName("page");

        RuleFor(q => q.Type)
            .IsInEnum().WithMessage("O tipo do imovel precisa ser válido")
            .OverridePropertyName("type");

        RuleFor(q => q.City)
            .NotEmpty().WithMessage("A cidade precisa ser fornecida")
            .OverridePropertyName("city");
    }
}