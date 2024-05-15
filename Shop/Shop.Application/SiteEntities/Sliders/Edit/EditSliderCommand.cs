using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommand : IBaseCommand
{
    public long SliderId { get; private set; }
    public string Link { get; private set; }
    public IFormFile? ImageFile { get; private set; }
    public string Title { get; private set; }

    public EditSliderCommand(long sliderId, string link, IFormFile? imageFile, string title)
    {
        SliderId = sliderId;
        Link = link;
        ImageFile = imageFile;
        Title = title;
    }
}