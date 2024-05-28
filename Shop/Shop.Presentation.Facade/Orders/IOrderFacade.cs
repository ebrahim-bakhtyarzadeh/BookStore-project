using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;

namespace Shop.Presentation.Facade.Orders;

internal interface IOrderFacade
{
    //command
    Task<OperationResult> AddItem(AddOrderItemCommand command);
    Task<OperationResult> CheckoutOrder(AddOrderItemCommand command);
    Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand command);


    //queries

    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams param);
    Task<OrderDto> GetOrderById(int id);



}