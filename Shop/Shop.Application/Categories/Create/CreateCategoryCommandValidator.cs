using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.title)
            .NotEmpty().NotNull().WithMessage(ValidationMessages.required("title"));
        RuleFor(r => r.slug)
            .NotEmpty().NotNull().WithMessage(ValidationMessages.required("slug"));
    }
}