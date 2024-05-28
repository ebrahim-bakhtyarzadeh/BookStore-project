using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.GetById;
using Shop.Query.Orders.GetOrderByFilter;

namespace Shop.Presentation.Facade.Orders;

internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CheckoutOrder(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> RemoveItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams param)
    {
        return await _mediator.Send(new GetOrderByFilterQuery(param));
    }

    public async Task<OrderDto> GetOrderById(int id)
    {
        return await _mediator.Send(new GetOrderByIdQuery(id));
    }
}