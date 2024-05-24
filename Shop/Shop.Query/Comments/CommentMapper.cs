using Shop.Domain.CommentAgg;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments
{
    internal static class CommentMapper
    {
        public static CommentDto? MapComment(this Comment? comment)
        {
            if (comment == null)
            {
                return null;
            }
            return new CommentDto()
            {
                Id = comment.Id,
                ProductId = comment.ProductId,
                Status = comment.Status,
                TextComment = comment.TextComment,
                UpdateDate = comment.UpdateDate,
                UserId = comment.UserId,
                CreationDate = comment.CreationDate,
            };
        }
    }
}
