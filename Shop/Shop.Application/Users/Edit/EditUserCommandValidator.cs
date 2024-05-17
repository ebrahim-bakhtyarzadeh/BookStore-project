using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(u => u.PhoneNumber)
            .ValidPhoneNumber();
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email is not valid");
        RuleFor(u => u.Password)
            .MinimumLength(4)
            .WithMessage("Password must be more than 4 characters");
        RuleFor(u => u.Avatar)
            .JustImageFile();
    }
}