﻿using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Security;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers;



[PermissionChecker(Permission.Manage_User)]

public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;

    public UsersController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery]UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }

    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }
}