using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(r => r.textComment)
            .NotNull()
            .MinimumLength(5)
            .WithMessage(ValidationMessages.minLength("Comment", 5));
    }
}