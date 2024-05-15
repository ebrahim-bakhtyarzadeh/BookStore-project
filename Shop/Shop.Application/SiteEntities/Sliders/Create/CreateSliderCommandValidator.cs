using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("Title"))
            .NotNull();
        RuleFor(r => r.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("Image File"))
            .JustImageFile();
        RuleFor(b => b.Link)
            .NotEmpty().WithMessage(ValidationMessages.required("Link"))
            .NotNull();
    }
}