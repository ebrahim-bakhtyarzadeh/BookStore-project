using Common.Query;

namespace Shop.Query.SiteEntities.DTOs;

public class ShippingMethodDto : BaseDTO
{
    public string Title { get; set; }
    public int Cost { get; set; }
}