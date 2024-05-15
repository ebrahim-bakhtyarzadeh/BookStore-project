using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
{
    public EditSliderCommandValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(r => r.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("Image File"))
            .JustImageFile();
        RuleFor(b => b.Link)
            .NotEmpty().WithMessage(ValidationMessages.required("Link"))
            .NotNull();
    }
}