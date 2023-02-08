using FluentValidation;
using ParamoChallenge.Core.DTOs;

namespace ParamoChallenge.Infrastructure.Validator
{
    public class ArticleValidator:AbstractValidator<ArticleDto>
    {
        public ArticleValidator()
        {
            RuleFor(article => article.Name)
                .NotNull()
                .NotEmpty()
                .Length(4,250);
        }
    }
}
