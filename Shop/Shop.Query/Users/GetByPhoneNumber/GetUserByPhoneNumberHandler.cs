using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberHandler : IQueryHandler<GetUserByPhoneNumber, UserDto?>
{
    private readonly ShopContext _context;

    public GetUserByPhoneNumberHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumber request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber == request.phoneNumber, cancellationToken);
        if (user == null)
        {
            return null;
        }
        return await user.Map().SetUserRoleTitles(_context);
    }
}