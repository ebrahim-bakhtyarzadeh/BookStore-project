using Common.Query;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Query.Users.DTOs
{
    public class UserDto : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string AvatarName { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
}
