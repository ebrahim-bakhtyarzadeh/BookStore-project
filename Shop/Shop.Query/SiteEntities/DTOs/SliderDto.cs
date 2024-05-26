using Common.Query;

namespace Shop.Query.SiteEntities.DTOs;

public class SliderDto : BaseDTO
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}