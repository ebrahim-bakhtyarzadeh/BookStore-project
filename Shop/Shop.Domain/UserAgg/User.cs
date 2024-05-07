using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string firstName, string lastName, string phoneNumber, string email, string password, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }

        public void Edit(string firstName, string lastName, string phoneNumber, string email, string password, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public static User RegisterUser(string email, string phoneNumber, string password, IDomainUserService domainUserService)
        {
            return new User("", "", phoneNumber, email, password, Gender.None, domainUserService);
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

        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.UserId == address.UserId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }

            Addresses.Remove(oldAddress);
            Addresses.Add(address);

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

        public void Guard(string phoneNumber, string email, IDomainUserService domainUserService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(Email, nameof(Email));

            if (phoneNumber.Length != 11)
            {
                throw new InvalidDomainDataException("phone number is not Valid");
            }

            if (email.IsValidEmail() == false)
            {
                throw new InvalidDomainDataException("email is not valid");
            }

            if (phoneNumber != PhoneNumber)
            {
                if (domainUserService.PhoneNumberIsExist(phoneNumber))
                {
                    throw new InvalidDomainDataException("The phone number is duplicated");
                }
            }
            if (email != Email)
            {
                if (domainUserService.IsEmailExist(email))
                {
                    throw new InvalidDomainDataException("The phone number is duplicated");
                }
            }
        }

    }
}
