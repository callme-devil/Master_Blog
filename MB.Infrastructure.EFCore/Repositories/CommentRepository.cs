using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

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

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(),
                Article = x.Article.Title
            }).ToList();
        }
    }
}
