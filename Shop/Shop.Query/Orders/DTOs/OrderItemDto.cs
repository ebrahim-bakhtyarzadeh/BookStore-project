using Common.Query;

namespace Shop.Query.Orders.DTOs;

public class OrderItemDto : BaseDTO
{
    public long OrderId { get; set; }
    public long InventoryId { get; set; }

    public string ShopName { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
    public string ProductTitle { get; set; }
    public string ProductSlug { get; private set; }
    public string ProductImageName { get; set; }
}