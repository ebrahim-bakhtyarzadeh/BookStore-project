using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById
{
    public class GetUserByIdQuery : IQuery<UserDto?>
    {
        public long UserId { get; private set; }

        public GetUserByIdQuery(long userId)
        {
            UserId = userId;
        }
    }
}
