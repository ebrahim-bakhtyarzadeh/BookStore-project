using Common.Query;

namespace Shop.Query.Products.DTOs;

public class ProductImageDto : BaseDTO
{
    public long ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}