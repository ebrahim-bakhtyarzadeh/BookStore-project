using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(long Id, CommentStatus status) : IBaseCommand
    {
    }

    public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
    {
        private readonly ICommentRepository _commentRepository;
        public ChangeCommentStatusCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetTracking(request.Id);
            if (comment == null)
            {
                return OperationResult.NotFound();
            }
            comment.ChangeStatus(request.status);
            _commentRepository.Update(comment);
            await _commentRepository.Save();
            return OperationResult.Success();
        }
    }
}
