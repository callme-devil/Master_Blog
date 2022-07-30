using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Context;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository :ICommentRepository
    {
        private readonly MasterBlogContext _context;

        public CommentRepository(MasterBlogContext context)
        {
            _context = context;
        }


        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
