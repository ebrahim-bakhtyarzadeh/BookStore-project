using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public CommentStatus Status { get; private set; }
        public string TextComment { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public Comment(long userId, long productId, CommentStatus status, string textComment)
        {
            NullOrEmptyDomainDataException.CheckString(textComment, nameof(textComment));
            UserId = userId;
            ProductId = productId;
            Status = status;
            TextComment = textComment;

        }

        public void Edit(string textComment)
        {
            NullOrEmptyDomainDataException.CheckString(textComment, nameof(textComment));

            TextComment = textComment;
            UpdateDate = DateTime.Now;
        }

        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }
    }
}
