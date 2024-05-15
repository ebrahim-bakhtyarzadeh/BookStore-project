using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.AddInventory;

internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _sellerRepository;

    public AddSellerInventoryCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }

        var newInventory = new SellerInventory(request.ProductId, request.Count, request.Price,
            request.DiscountPercentage);
        seller.AddInventory(newInventory);
        await _sellerRepository.Save();


        return OperationResult.Success();
    }

}