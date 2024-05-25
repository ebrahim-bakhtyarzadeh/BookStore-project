using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto : BaseDTO
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public OrderDiscount? Discount { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public OrderAddress? Address { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
