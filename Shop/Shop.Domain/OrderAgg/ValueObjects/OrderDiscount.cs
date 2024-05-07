namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : Common.Domain.ValueObject
    {
        public string DiscountTitle { get; private set; }
        public int DiscountAmount { get; private set; }

        public OrderDiscount(string discountTitle, int discountAmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmount = discountAmount;
        }
    }
}
