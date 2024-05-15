using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Edit;

internal class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Title"));
        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Description"));

        RuleFor(r => r.Slug)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Slug"));

        RuleFor(r => r.ImageFile)
            .JustImageFile();
    }
}