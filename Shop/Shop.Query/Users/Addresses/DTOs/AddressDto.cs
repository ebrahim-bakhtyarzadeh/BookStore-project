
using Common.Query;

namespace Shop.Query.Users.Addresses.DTOs
{
    public class AddressDto : BaseDTO
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Shire { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public bool ActiveAddress { get; set; }
    }
}
