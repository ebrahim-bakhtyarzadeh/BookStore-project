using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
{
    public EditBannerCommandValidator()
    {
        RuleFor(r => r.ImageFile)

            .JustImageFile();
        RuleFor(b => b.Link)
            .NotEmpty().WithMessage(ValidationMessages.required("Link"))
            .NotNull();
    }
}