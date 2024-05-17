using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
{
    public AddUserAddressCommandValidator()
    {
        RuleFor(u => u.City)
            .NotEmpty().WithMessage(ValidationMessages.required("City"));
        RuleFor(u => u.Shire)
            .NotEmpty().WithMessage(ValidationMessages.required("Shire"));
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage(ValidationMessages.required("FirstName"));
        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage(ValidationMessages.required("LastName"));
        RuleFor(u => u.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("NationalCode")).ValidNationalCode();

        RuleFor(u => u.PostalAddress)
            .NotEmpty().WithMessage(ValidationMessages.required("PostalAddress"));
        RuleFor(u => u.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("PostalCode"));
    }
}