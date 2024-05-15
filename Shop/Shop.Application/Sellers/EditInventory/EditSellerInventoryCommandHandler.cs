using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.EditInventory;

internal class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
{
    private readonly ISellerRepository _sellerRepository;

    public EditSellerInventoryCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.EditInventory(request.InventoryId, request.Count, request.Price, request.DiscountPercentage);
        _sellerRepository.Save();
        return OperationResult.Success();


    }
}