using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Sliders.Create;

internal class CreateSliderCommandHandelr : IBaseCommandHandler<CreateSliderCommand>
{
    private readonly IFileService _fileService;
    private readonly ISliderRepository _sliderRepository;

    public CreateSliderCommandHandelr(IFileService fileService, ISliderRepository sliderRepository)
    {
        _fileService = fileService;
        _sliderRepository = sliderRepository;
    }
    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService
            .SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
        var slider = new Slider(request.Title, request.Link, imageName);
        _sliderRepository.Add(slider);
        await _sliderRepository.Save();
        return OperationResult.Success();
    }
}