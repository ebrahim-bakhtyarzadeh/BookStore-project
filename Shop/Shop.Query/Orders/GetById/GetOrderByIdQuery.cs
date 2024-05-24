using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto>;

    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly DapperContext _dapper;
        private readonly ShopContext _context;

        public GetOrderByIdQueryHandler(ShopContext context, DapperContext dapper)
        {
            _dapper = dapper;
            _context = context;
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return null;
            }

            var orderDto = order.Map();
            orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
                .Select(s => $"{s.FirstName} {s.LastName}").FirstAsync();

            orderDto.Items = await orderDto.GetOrderItems(_dapper);

            return orderDto;


        }
    }

}
