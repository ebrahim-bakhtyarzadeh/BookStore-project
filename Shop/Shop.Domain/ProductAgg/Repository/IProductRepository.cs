using Common.Domain;

namespace Shop.Domain.ProductAgg.Repository;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<bool> DeleteCategory(long categoryId);
}