using ArtisanGemstoneIMS.WebUI.Shared.Products;
using FluentValidation;

namespace ArtisanGemstoneIMS.Application.Products;

public class BaseProductValidator : AbstractValidator<BaseProductDto>
{
    public BaseProductValidator()
    {
        RuleFor(p => p.Sku)
            .NotNull()
            .WithMessage("{PropertyName} does not exist.");
    }
}
