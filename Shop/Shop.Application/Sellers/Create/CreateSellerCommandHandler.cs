using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create;

internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _sellerDomainService;

    public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService sellerDomainService)
    {
        _repository = repository;
        _sellerDomainService = sellerDomainService;
    }

    public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _sellerDomainService);
        _repository.Add(seller);
        await _repository.Save();
        return OperationResult.Success();
    }
}