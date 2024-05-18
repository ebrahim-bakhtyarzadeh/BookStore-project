using Dapper;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        //public async Task<InventoryResult?> GetInventoryById(long id)
        //{
        //    return await _context.Inventories.Where(r => r.Id == id).Select(i => new InventoryResult()
        //    {
        //        Count = i.Count,
        //        InventoryId = i.Id,
        //        Price = i.Price,
        //        ProductId = i.ProductId,
        //        SellerId = i.SellerId,
        //    }).FirstOrDefaultAsync();
        //}
        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            using var sqlConnection = _dapperContext.CreateConnection();
            var sqlQuery = $"SELECT * FROM {_dapperContext.Inventories} WHERE Id =@id";
            var result = await sqlConnection.QueryFirstOrDefaultAsync<InventoryResult>(sqlQuery, new
            {
                id = id
            });
            return result;
        }

    }
}
