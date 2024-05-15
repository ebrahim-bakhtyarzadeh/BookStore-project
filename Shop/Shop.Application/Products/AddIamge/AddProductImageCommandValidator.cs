using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddIamge;

public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
{
    public AddProductImageCommandValidator()
    {
        RuleFor(p => p.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("Image"))
            .JustImageFile();
        RuleFor(p => p.Sequence)
            .GreaterThanOrEqualTo(0);
    }
}