using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidator()
    {
        RuleFor(s => s.ShopName)
            .NotEmpty().WithMessage(ValidationMessages.required("Shop Name"));
        RuleFor(s => s.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("National Code"))
            .ValidNationalId();
    }
}