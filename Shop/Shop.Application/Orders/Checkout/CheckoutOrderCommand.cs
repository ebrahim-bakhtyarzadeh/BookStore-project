using Common.Application;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommand : IBaseCommand
    {
        public CheckoutOrderCommand(long userId, string firstName, string lastName, string shire, string city, string postalCode, string postalAddress, string phoneNumber, string nationalCode, bool activeAddress)
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
            ActiveAddress = activeAddress;
        }
        public long UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddress { get; private set; }
    }
}
