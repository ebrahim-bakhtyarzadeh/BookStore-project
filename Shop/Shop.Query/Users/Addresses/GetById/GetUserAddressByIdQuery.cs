using Common.Query;
using Shop.Query.Users.Addresses.DTOs;

namespace Shop.Query.Users.Addresses.GetById
{
    public record GetUserAddressByIdQuery(long addressId) : IQuery<AddressDto?>;
}
