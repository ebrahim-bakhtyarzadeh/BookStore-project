using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResutl, SellerFilterParams?>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
    public class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResutl?>
    {
        private readonly ShopContext _context;

        public GetSellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SellerFilterResutl?> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Seller.OrderByDescending(d => d.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.NationalCode))
                result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

            if (!string.IsNullOrWhiteSpace(@params.ShopName))
                result = result.Where(r => r.ShopName.Contains(@params.ShopName));

            var skip = (@params.PageId - 1) * @params.Take;

            var sellerResult = new SellerFilterResutl()
            {
                FilterParams = @params,
                Data = await result.Skip(skip).Take(@params.Take)
                    .Select(s => s.Map())
                    .ToListAsync(cancellationToken)
            };
            sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
            return sellerResult;
        }
    }
}
