using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetList;

public class GetInventoriesQueryHandler : IQueryHandler<GetInventoriesQuery, List<InventoryDto>?>
{
    private readonly DapperContext _dapperContext ;
    public GetInventoriesQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<List<InventoryDto>?> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();

        var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM 
        {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id  
            inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE i.SellerId=@sellerId";

        var inventories = await connection.QueryAsync<InventoryDto>(sql, new { sellerId = request.sellerId });
        if (inventories == null)
        {
            return null;
        }
        return inventories.ToList();


    }
}
