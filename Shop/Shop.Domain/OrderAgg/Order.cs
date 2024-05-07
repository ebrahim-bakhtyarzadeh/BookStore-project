using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }
        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public OrderAddress? Address { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(s => s.TotalPrice);
                if (ShippingMethod != null)
                {
                    totalPrice += ShippingMethod.ShippingCost;
                }

                if (Discount != null)

                    totalPrice -= Discount.DiscountAmount;


                return totalPrice;
            }
        }

        public int ItemCount => Items.Count;



        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(long itemId)
        {
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem != null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress)
        {
            Address = orderAddress;
        }
    }

    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }
        public string ShippingType { get; private set; }
        public int ShippingCost { get; private set; }
    }
}
