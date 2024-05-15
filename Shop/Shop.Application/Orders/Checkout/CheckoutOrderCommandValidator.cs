using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(f => f.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("First Name"));
        RuleFor(f => f.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Last Name"));
        RuleFor(f => f.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("City"));
        RuleFor(f => f.Shire)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Shire"));

        RuleFor(f => f.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Postal Address"));

        RuleFor(f => f.PostalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Postal Code"));

        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MaximumLength(11)
            .WithMessage(ValidationMessages.required("Phone Number"))
            .MinimumLength(11)
            .WithMessage(ValidationMessages.required("Phone Number"));
        RuleFor(f => f.NationalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("National Code"))
            .MaximumLength(10).WithMessage("National Code")
            .MinimumLength(10).WithMessage("National Code")
            .ValidNationalId();

    }
}