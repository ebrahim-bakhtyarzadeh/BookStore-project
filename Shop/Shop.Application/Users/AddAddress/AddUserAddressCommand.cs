using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }


        public AddUserAddressCommand(long userId, string firstName, string lastName, string shire, string city,
            string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
        {
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
}
