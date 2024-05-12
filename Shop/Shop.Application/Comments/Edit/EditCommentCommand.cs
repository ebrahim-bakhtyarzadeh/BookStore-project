using Common.Application;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long CommentId, long UserId, string textComment) : IBaseCommand;
}
