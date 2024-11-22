using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banners.Delete
{
    public record DeleteBannerCommand(long Id) : IBaseCommand;
    internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IFileService _localFileService;
        public DeleteBannerCommandHandler(IBannerRepository bannerRepository, IFileService localFileService)
        {
            _bannerRepository = bannerRepository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetTracking(request.Id);
            if (banner == null)
                return OperationResult.NotFound();

            _bannerRepository.Delete(banner);
            await _bannerRepository.Save();
            _localFileService.DeleteFile(Directories.BannerImages, banner.ImageName);
            return OperationResult.Success();
        }
    }
}
