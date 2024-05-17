using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {

        public long UserId { get; private set; }
        public IFormFile? Avatar { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }

        public EditUserCommand(long userId, IFormFile? avatar, string firstName, string lastName, string phoneNumber, string email, string password, Gender gender)
        {
            UserId = userId;
            Avatar = avatar;

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;

        }
    }
}
