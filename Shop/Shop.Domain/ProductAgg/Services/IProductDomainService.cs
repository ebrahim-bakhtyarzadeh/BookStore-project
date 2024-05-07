namespace Shop.Domain.ProductAgg.Services;

public interface IProductDomainService
{
    public bool SlugIsExist(string slug);

}