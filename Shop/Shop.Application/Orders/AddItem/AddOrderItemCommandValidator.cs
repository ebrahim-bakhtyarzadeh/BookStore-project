using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidator()
    {
        RuleFor(f => f.Count)
            .GreaterThan(1).WithMessage("The input number must not be less than 1");
    }
}