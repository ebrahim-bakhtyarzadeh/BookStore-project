namespace Shop.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool CheckSellerIsExist(Seller seller);
    bool NationalCodeIsExist(string nationalCode);
}