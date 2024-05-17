using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress;

internal class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
        {
            OperationResult.NotFound();
        }

        var UserAddress = new UserAddress(request.FirstName, request.LastName, request.Shire, request.City,
            request.PostalCode, request.PostalAddress, request.PhoneNumber, request.NationalCode);
        user.AddAddress(UserAddress);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}