using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }


        public bool CheckSellerIsExist(Seller seller)
        {
            return _repository.Exists(s => s.NationalCode == seller.NationalCode || s.Id == seller.Id);
        }

        public bool NationalCodeIsExist(string nationalCode)
        {
            return _repository.Exists(s => s.NationalCode == nationalCode);

        }
    }
}
