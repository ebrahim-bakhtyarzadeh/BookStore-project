using Common.Query;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Query.Comments.DTOs
{
    public class CommentDto : BaseDTO
    {

        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public long ProductId { get; set; }
        public CommentStatus Status { get; set; }
        public string TextComment { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ProductTitle { get; set; }
    }
}
