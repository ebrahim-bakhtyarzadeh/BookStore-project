using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug
{
    public record GetProductBySlugQuery(string slug) : IQuery<ProductDto?>;
}
