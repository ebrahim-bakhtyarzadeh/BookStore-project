using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerCommandValidator()
    {
        RuleFor(r => r.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("Image File"))
            .JustImageFile();
        RuleFor(b => b.Link)
            .NotEmpty().WithMessage(ValidationMessages.required("Link"))
            .NotNull();
    }

}