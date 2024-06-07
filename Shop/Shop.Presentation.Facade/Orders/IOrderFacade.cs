using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;

namespace Shop.Presentation.Facade.Orders;

public interface IOrderFacade
{
    //command
    Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
    Task<OperationResult> CheckoutOrder(CheckoutOrderCommand command);
    Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand command);


    //queries

    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams param);
    Task<OrderDto> GetOrderById(long id);



}