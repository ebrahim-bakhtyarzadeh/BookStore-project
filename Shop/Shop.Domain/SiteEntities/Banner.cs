using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Domain.SiteEntities;

public class Banner : BaseEntity
{
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition BannerPosition { get; private set; }

    public Banner(string link, string imageName, BannerPosition bannerPosition)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }

    public void Edit(string link, string imageName, BannerPosition bannerPosition)
    {
        Guard(link, imageName);

        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));


    }
}