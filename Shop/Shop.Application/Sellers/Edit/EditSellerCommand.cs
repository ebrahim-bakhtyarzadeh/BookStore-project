using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long SellerId, string ShopName, string NationalCode, SellerStatus status) : IBaseCommand;
}
