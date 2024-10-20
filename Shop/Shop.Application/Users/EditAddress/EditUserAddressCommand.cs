using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;

namespace Shop.Application.Users.EditAddress
{
	public class EditUserAddressCommand : IBaseCommand
	{
		public long Id { get; private set; }
		public long UserId { get; set; }
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

	internal class EditUserAddressCommandValidator : AbstractValidator<EditUserAddressCommand>
	{
	}
}
