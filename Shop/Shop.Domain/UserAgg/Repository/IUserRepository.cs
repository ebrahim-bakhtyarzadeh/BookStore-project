using Common.Domain;

namespace Shop.Domain.UserAgg.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    UserAddress getUserAddressById(long addressId);
}