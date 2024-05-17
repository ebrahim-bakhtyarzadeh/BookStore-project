using Shop.Domain.CommentAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }

        public async Task DeleteAndSave(Comment comment)
        {
            _context.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
