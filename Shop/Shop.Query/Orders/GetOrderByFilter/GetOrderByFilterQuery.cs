using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetOrderByFilter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
