using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetOrderByFilter;

internal class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    private readonly ShopContext _shopContext;

    public GetOrderByFilterQueryHandler(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;
        var result = _shopContext.Orders.OrderByDescending(d => d.Id).AsQueryable();

        if (@param.Status != null)
            result = result.Where(r => r.Status == param.Status);
        if (@param.UserId != null)
            result = result.Where(r => r.UserId == param.UserId);

        if (@param.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= param.StartDate.Value.Date);

        if (@param.EndDate != null)
            result = result.Where(r => r.LastUpdate.Date >= param.EndDate.Value.Date);



        var skip = (param.PageId - 1) * param.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(param.Take)
                .Select(order => order.MapFilterData(_shopContext))
                .ToListAsync(cancellationToken),
            FilterParams = @param
        };
        model.GeneratePaging(result, param.Take, param.PageId);
        return model;
    }
}