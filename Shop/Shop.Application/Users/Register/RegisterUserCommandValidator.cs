using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Password)
            .NotNull().WithMessage(ValidationMessages.required("Password"))
            .NotEmpty().WithMessage(ValidationMessages.required("Password"))
            .MinimumLength(4).WithMessage("Password must be more than 4 characters");
    }
}