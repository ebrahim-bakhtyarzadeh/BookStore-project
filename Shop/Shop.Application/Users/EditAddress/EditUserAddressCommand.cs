using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress
{
    internal class EditUserAddressCommand : IBaseCommand
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }

        public EditUserAddressCommand(long id, long userId, string firstName, string lastName, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
    }
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
    internal class EditUserAddressCommandValidator : AbstractValidator<EditUserAddressCommand>
    {
    }
}
