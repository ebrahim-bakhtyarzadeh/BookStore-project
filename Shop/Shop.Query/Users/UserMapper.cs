﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                AvatarName = user.AvatarName,
                Email = user.Email,
                Gender = user.Gender,
                FirstName = user.FirstName,
                Password = user.Password,
                IsActive = user.IsActive,
                Roles = user.Roles.Select(s => new UserRoleDto()
                {
                    RoleId = s.RoleId,
                    RoleTitle = ""
                }).ToList()
            };
        }

        public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
        {
            var roleIds = userDto.Roles.Select(r => r.RoleId);
            var result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
            var roles = new List<UserRoleDto>();
            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title
                });
            }

            userDto.Roles = roles;
            return userDto;
        }

        public static UserFilterData? MapFilterData(this User? user)
        {
            if (user == null)
                return null;
            return new UserFilterData()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                AvatarName = user.AvatarName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
            };
        }


    }
}
