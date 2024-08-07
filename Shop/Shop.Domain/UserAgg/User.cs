using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User()
        {

        }
        public User(string firstName, string lastName, string phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            IsActive = true;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; private set; }
        public string AvatarName { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }

        public void Edit(string firstName, string lastName, string phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = "avatar.png";
        }

        public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
        {
            return new User("", "", phoneNumber, "", password, Gender.None, userDomainService);
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void RemoveAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.UserId == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(oldAddress);

        }

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "avatar.png";

            AvatarName = imageName;
        }

        public void EditAddress(UserAddress address, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.UserId == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            oldAddress.Edit(address.FirstName, address.LastName, address.Shire, address.City, address.PostalCode
                , address.PostalAddress, address.PhoneNumber, address.NationalCode);



        }

        public void ChargeWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(r => r.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(Email, nameof(Email));

            if (phoneNumber.Length != 11)
            {
                throw new InvalidDomainDataException("phone number is not Valid");
            }
            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException("email is not valid");


            if (phoneNumber != PhoneNumber)
            {
                if (userDomainService.PhoneNumberIsExist(phoneNumber))
                {
                    throw new InvalidDomainDataException("The phone number is duplicated");
                }
            }

            if (email != Email)
                if (userDomainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("The phone number is duplicated");

        }

    }
}
