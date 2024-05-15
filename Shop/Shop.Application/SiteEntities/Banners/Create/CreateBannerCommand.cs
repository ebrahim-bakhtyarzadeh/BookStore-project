using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommand : IBaseCommand
{
    public string Link { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public BannerPosition BannerPosition { get; private set; }

    public CreateBannerCommand(string link, IFormFile imageFile, BannerPosition bannerPosition)
    {
        Link = link;
        ImageFile = imageFile;
        BannerPosition = bannerPosition;
    }
}