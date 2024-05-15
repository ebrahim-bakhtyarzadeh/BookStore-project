using Common.Domain;

namespace Shop.Domain.OrderAgg.Repository;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> GetCurrentUserOrder(long userId);
}