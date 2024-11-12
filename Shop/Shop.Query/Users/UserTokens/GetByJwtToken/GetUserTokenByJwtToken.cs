using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.UserTokens.GetByRefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.UserTokens.GetByJwtToken;
public class GetUserTokenByJwtToken
{
}
public record GetUserTokenByJwtTokenQuery(string hashJwtToken) : IQuery<UserTokenDto>;



internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} WHERE HashJwtToken=@HashJwtToken";
        return await connection.QueryFirstOrDefaultAsync<UserTokenDto?>(sql, new { request.hashJwtToken });
    }
}