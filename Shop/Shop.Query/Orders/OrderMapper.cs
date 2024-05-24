using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders;
public static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {


        return new OrderDto()
        {
            CreationDate = order.CreationDate,
            Id = order.Id,
            Status = order.Status,
            Address = order.Address,
            Discount = order.Discount,
            Items = new(),
            LastUpdate = order.LastUpdate,
            ShippingMethod = order.ShippingMethod,
            UserFullName = "",
            UserId = order.UserId,
        };

    }


    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapper)
    {
        var model = new List<OrderItemDto>();

        using var connection = dapper.CreateConnection();
        var sql = @$"SELECT s.ShopName,o.OrderId,o.InventoryId,o.Count,o.Price,
                    p.Title as [Product.Title],p.Slug as [Product.Slug],
                    p.ImageName as [Product.ImageName]
                    FROM {dapper.OrderItems} o  
                    inner join {dapper.Inventories} i on o.InventoryId=i.Id
                    inner join {dapper.Products} p on i.ProductId=p.Id
                    inner join {dapper.Sellers} s on i.SellerId=s.Id
                    where o.OrderId=@orderId";
        var result = await connection
            .QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });


        return result.ToList();
    }

    public static OrderFilterData MapFilterData(this Order order, ShopContext _context)
    {
        var userFullName = _context.Users
            .Where(r => r.Id == order.UserId)
            .Select(u => $"{u.FirstName} {u.LastName}")
            .First();
        return new OrderFilterData()
        {
            Status = order.Status,
            Id = order.Id,
            CreationDate = order.CreationDate,
            City = order.Address?.City,
            shippingType = order.ShippingMethod?.ShippingType,
            Shire = order.Address?.Shire,
            TotalItemCount = order.ItemCount,
            TotalPrice = order.TotalPrice,
            UserFullName = userFullName,
            UserId = order.UserId
        };
    }
}

