using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommand : IBaseCommand
{
    public long BannerId { get; private set; }
    public string Link { get; private set; }
    public IFormFile? ImageFile { get; private set; }
    public BannerPosition BannerPosition { get; private set; }

    public EditBannerCommand(string link, IFormFile? imageFile, BannerPosition bannerPosition, long bannerId)
    {
        Link = link;
        ImageFile = imageFile;
        BannerPosition = bannerPosition;
        BannerId = bannerId;
    }
}