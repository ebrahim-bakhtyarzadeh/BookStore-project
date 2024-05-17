using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Common.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is > 11 or < 11)
            {
                throw new InvalidDomainDataException("Phone number is not valid");
            }

            Value = value;
        }
    }
}
