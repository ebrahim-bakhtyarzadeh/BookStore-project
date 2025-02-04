﻿using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Security;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Api.Controllers;

[PermissionChecker(Permission.CRUD_Slider)]

public class SliderController : ApiController
{
    private readonly ISliderFacade _facade;


    public SliderController(ISliderFacade facade)
    {
        _facade = facade;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<List<SliderDto>>> GetList()
    {
        var result = await _facade.GetSliders();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<SliderDto?>> GetById(long id)
    {
        var result = await _facade.GetSliderById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreateSliderCommand command)
    {
        var result = await _facade.CreateSlider(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit(EditSliderCommand command)
    {
        var result = await _facade.EditSlider(command);
        return CommandResult(result);
    }
}