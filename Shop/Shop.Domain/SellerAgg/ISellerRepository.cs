using Common.Domain;

namespace Shop.Domain.SellerAgg;

public interface ISellerRepository : IBaseRepository<Seller>
{
    public Task<InventoryResult?> GetInventoryById(long id);
}

public class InventoryResult()
{
    public long InventoryId { get; set; }
    public long SellerId { get; set; }
    public long ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}