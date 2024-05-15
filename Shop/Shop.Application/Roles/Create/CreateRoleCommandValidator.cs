using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create;

internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Title"));
    }
}