using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(r => r.textComment)
            .NotNull()
            .MinimumLength(5)
            .WithMessage(ValidationMessages.minLength("Comment", 5));


    }
}