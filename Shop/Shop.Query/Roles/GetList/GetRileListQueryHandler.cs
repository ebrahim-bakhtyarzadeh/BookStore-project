using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList;

public class GetRileListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly ShopContext _context;

    public GetRileListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {

        return await _context.Roles.Select(s => new RoleDto()
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Permissions = s.Permissions.Select(p => p.Permission).ToList(),
            Title = s.Title,
        }).ToListAsync(cancellationToken);






    }
}