using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    private readonly ShopContext _context;

    public GetProductBySlugQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Slug == request.slug, cancellationToken);

        var model = product.Map();
        await model.SetCategories(_context);
        if (model == null)
        {
            return null;
        }
        return model;
    }

}