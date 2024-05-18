using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    public record GetCommentById(long Id) : IQuery<CommentDto?>;
}
