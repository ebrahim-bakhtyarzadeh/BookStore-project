using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByPhoneNumber
{
    public record GetUserByPhoneNumber(string phoneNumber) : IQuery<UserDto?>;
}
