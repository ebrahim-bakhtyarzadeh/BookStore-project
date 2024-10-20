using AspNetCore;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers
{
	public class AuthController : ApiController
	{
		private readonly IUserFacade _userFacade;
		private readonly IConfiguration _configuration;
		public AuthController(IUserFacade userFacade, IConfiguration configuration)
		{
			_userFacade = userFacade;
			_configuration = configuration;
		}

		#region Login
		[HttpPost("login")]
		public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
		{

			var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
			if (user == null)
			{
				var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
				return CommandResult(result);
			}

			if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
			{
				var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
				return CommandResult(result);
			}

			if (user.IsActive == false)
			{
				var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
				return CommandResult(result);
			}


			var loginResult = await AddTokenAndGenerateResult(user);
			return CommandResult(loginResult);
		}


		#endregion


		#region Register

		[HttpPost("register")]
		public async Task<ApiResult> Register(RegisterViewModel register)
		{
			if (ModelState.IsValid == false)
			{
				return new ApiResult()
				{
					IsSuccess = false,
					MetaData = new()
					{
						AppStatusCode = AppStatusCode.BadRequest,
						Message = JoinErrors()
					}
				};
			}

			var command = new RegisterUserCommand(new PhoneNumber(register.PhoneNumber), register.Password);
			var result = await _userFacade.RegisterUser(command);
			return CommandResult(result);
		}

		#endregion

		#region RefreshToken
		//[HttpPost("RefreshToken")]
		//public async Task<ApiResult> RefreshToken(string refreshToken)
		//{


		//	return CommandResult(result);
		//}


		#endregion

		private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateResult(UserDto user)
		{

			var token = JwtTokenBuilder.BuildToken(user, _configuration);
			var refreshToken = Guid.NewGuid().ToString();
			var hashJwtToken = Sha256Hasher.Hash(token);
			var hashJwtRefreshToken = Sha256Hasher.Hash(refreshToken);
			var uaParser = Parser.GetDefault();
			var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
			var userDevice = $"{info.Device.Family} / {info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
			var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwtToken, hashJwtRefreshToken,
				DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), userDevice));

			if (tokenResult.Status != OperationResultStatus.Success)
				return OperationResult<LoginResultDto?>.Error();
			return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
			{
				RefreshToken = refreshToken,
				AccessToken = token
			});
		}
	}
}
