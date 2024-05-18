using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private ShopContext _context;

    public GetCommentByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;
        var result = _context.Comments.OrderByDescending(d => d.CreationDate).AsQueryable();

        if (@param.CommentStatus != null)
            result = result.Where(r => r.Status == param.CommentStatus);
        if (@param.UserId != null)
            result = result.Where(r => r.UserId == param.UserId);

        if (@param.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= param.StartDate.Value.Date);

        if (@param.EndDate != null)
            result = result.Where(r => r.UpdateDate.Date >= param.EndDate.Value.Date);

        var skip = (param.PageId - 1) * param.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(param.Take)
                .Select(comment => comment.MapComment()).ToListAsync(cancellationToken),
            FilterParams = @param
        };
        model.GeneratePaging(result, param.Take, param.PageId);
        return model;

    }
}