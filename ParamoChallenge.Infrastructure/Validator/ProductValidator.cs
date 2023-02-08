using FluentValidation;
using ParamoChallenge.Core.DTOs;

namespace ParamoChallenge.Infrastructure.Validator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
               .NotNull()
               .NotEmpty()
               .Length(4, 250);
            RuleFor(product => product.Description)
                .NotEmpty()
                .NotNull()
                 .Length(4, 250);
            RuleFor(product=>product.IdArticle)
                .NotEmpty()
                .NotNull();
        }
    }
}
