using Common.Query;
using Shop.Domain.OrderAgg;

namespace Shop.Query.Orders.DTOs;

public class OrderFilterData : BaseDTO
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? Shire { get; set; }
    public string? City { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
    public string? shippingType { get; set; }

}