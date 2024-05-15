using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit;

internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerRepository _sellerRepository;
    private readonly ISellerDomainService _sellerDomainService;

    public EditSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService sellerDomainService)
    {
        _sellerRepository = sellerRepository;
        _sellerDomainService = sellerDomainService;
    }
    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var Seller = await _sellerRepository.GetTracking(request.SellerId);
        if (Seller == null)
        {
            return OperationResult.NotFound();
        }
        Seller.Edit(request.ShopName, request.NationalCode, _sellerDomainService, request.status);
        await _sellerRepository.Save();
        return OperationResult.Success();
    }
}