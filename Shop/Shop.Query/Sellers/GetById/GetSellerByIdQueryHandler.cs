using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private readonly ShopContext _context;

    public GetSellerByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Seller.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        if (seller == null) return null;

        return seller.Map();



    }
}