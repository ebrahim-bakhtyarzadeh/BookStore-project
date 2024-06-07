namespace Shop.Api.ViewModels.Users
{
    public class EditUserAddressViewModel
    {
        public long Id { get; private set; }
        public long UserId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
    }
}
