﻿using Common.Application;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveUserToken;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users
{
	public interface IUserFacade
	{
		Task<OperationResult> RegisterUser(RegisterUserCommand command);
		Task<OperationResult> EditUser(EditUserCommand command);
		Task<OperationResult> CreateUser(CreateUserCommand command);
		Task<OperationResult> AddToken(AddUserTokenCommand command);
		Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
		Task<UserDto?> GetUserById(long userId);
		Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
		Task<UserTokenDto> GetUserTokenByJwtToken(string jwtToken);

	}
}