using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {

        RuleFor(u => u.PhoneNumber)
            .ValidPhoneNumber();
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email is not valid");
        RuleFor(u => u.Password)
            .NotNull().WithMessage(ValidationMessages.required("Password"))
            .NotEmpty().WithMessage(ValidationMessages.required("Password"))
            .MinimumLength(4)
            .WithMessage("Password must be more than 4 characters");


    }
}