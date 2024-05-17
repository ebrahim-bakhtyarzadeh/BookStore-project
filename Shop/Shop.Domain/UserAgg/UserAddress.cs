using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string firstName, string lastName, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
    {
        Guard(firstName, lastName, shire, city, postalCode, postalAddress, phoneNumber.Value, nationalCode);

        FirstName = firstName;
        LastName = lastName;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
        ActiveAddress = false;
    }

    public long UserId { get; internal set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }


    public void Edit(string firstName, string lastName, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
    {
        Guard(firstName, lastName, shire, city, postalCode, postalAddress, phoneNumber.Value, nationalCode);
        FirstName = firstName;
        LastName = lastName;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
    }

    public void Guard(string firstName, string lastName, string shire, string city, string postalCode,
        string postalAddress, string phoneNumber, string nationalCode)
    {
        NullOrEmptyDomainDataException.CheckString(firstName, nameof(firstName));
        NullOrEmptyDomainDataException.CheckString(lastName, nameof(lastName));
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
        {
            throw new InvalidDomainDataException("NationalCode Is Not Valid");
        }
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }

}