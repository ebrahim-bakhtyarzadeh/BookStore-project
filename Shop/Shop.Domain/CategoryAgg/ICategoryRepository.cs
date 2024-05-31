using Common.Domain;

namespace Shop.Domain.CategoryAgg;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public Task<bool> DeleteCategory(long categoryId);
}