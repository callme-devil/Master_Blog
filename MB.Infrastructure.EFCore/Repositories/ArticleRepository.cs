using System.Globalization;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:BaseRepository<long , Article> , IArticleRepository
    {
        private readonly MasterBlogContext _context;


        public ArticleRepository(MasterBlogContext context) : base(context)
        {
            _context = context;
        }


        public List<ArticleViewModel> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image
            }).ToList();
        }

    }
}
