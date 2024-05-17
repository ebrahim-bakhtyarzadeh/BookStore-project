using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _userDomainService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService, IFileService fileService)
    {
        _repository = repository;
        _userDomainService = userDomainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        var newPassword = Sha256Hasher.Hash(request.Password);

        var oldAvatar = user.AvatarName;
        user.Edit(request.FirstName, request.LastName, request.PhoneNumber, request.Email,
            newPassword, request.Gender, _userDomainService);
        if (request.Avatar != null)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
            user.SetAvatar(imageName);
        }




        await _repository.Save();
        return OperationResult.Success();
    }
    private void DeleteOldAvatar(IFormFile? imageFile, string oldAvatar)
    {
        if (imageFile == null || oldAvatar == "avatar.png")
        {
            return;
        }
        _fileService.DeleteFile(Directories.UserAvatars, oldAvatar);

    }
}