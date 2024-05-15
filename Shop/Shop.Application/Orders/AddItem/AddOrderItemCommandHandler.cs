using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory =await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();

        if (inventory.Count < request.Count)
            return OperationResult.Error("The required quantity is not available in stock");


        var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            order = new Order(request.UserId);

        order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
        if (ItemCountBiggerThanInventoryCount(inventory, order))
        {
            return OperationResult.Error("The required quantity is not available in stock");

        }
        await _orderRepository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.First(i => i.InventoryId == inventory.InventoryId);
        if (orderItem.Count>inventory.Count)
        {
            return true;
        }
        return false;
    }
}