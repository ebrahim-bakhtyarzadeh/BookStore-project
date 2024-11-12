﻿using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Security;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {

        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [PermissionChecker(Permission.Manage_Order)]
        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
        {
            var result = await _orderFacade.GetOrdersByFilter(filterParams);
            return QueryResult(result);
        }
        [HttpGet("{orderId}")]
        public async Task<ApiResult<OrderDto>> GetOrderById(long orderId)
        {
            var result = await _orderFacade.GetOrderById(orderId);
            return QueryResult(result);
        }


        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _orderFacade.AddOrderItem(command);
            return CommandResult(result);
        }

        [HttpPost("Checkout")]
        public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
        {
            var result = await _orderFacade.CheckoutOrder(command);
            return CommandResult(result);
        }

        [HttpPut("OrderItem/IncreaseCount")]
        public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.IncreaseOrderItemCount(command);
            return CommandResult(result);
        }

        [HttpPut("OrderItem/DecreaseCount")]
        public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.DecreaseOrderItemCount(command);
            return CommandResult(result);
        }


        [HttpDelete("OrderItem")]
        public async Task<ApiResult> RemoveOrderItem(RemoveOrderItemCommand command)
        {
            var result = await _orderFacade.RemoveItem(command);
            return CommandResult(result);
        }
    }
}
