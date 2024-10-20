using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
	private readonly IUserRepository _userRepository;

	public EditUserAddressCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}
	public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetTracking(request.Id);
		if (user == null)
		{
			return OperationResult.NotFound();
		}

		var address = new UserAddress(request.FirstName, request.LastName, request.Shire, request.City,
			request.PostalCode, request.PostalAddress, request.PhoneNumber, request.NationalCode);
		user.EditAddress(address, request.Id);
		await _userRepository.Save();
		return OperationResult.Success();
	}
}