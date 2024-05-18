using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById;

internal class GetCommentByIdHandler : IQueryHandler<GetCommentById, CommentDto?>
{
    private readonly ShopContext _context;

    public GetCommentByIdHandler(ShopContext context)
    {
        _context = context;
    }
    public async Task<CommentDto?> Handle(GetCommentById request, CancellationToken cancellationToken)
    {
        var result = await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        return result.MapComment();
    }
}