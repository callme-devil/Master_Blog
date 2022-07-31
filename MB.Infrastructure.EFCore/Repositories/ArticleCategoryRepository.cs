using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Context;

namespace MB.Infrastructure.EFCore.Repositories
{
    public  class ArticleCategoryRepository :BaseRepository<long,ArticleCategory> , IArticleCategoryRepository
    {
        private readonly MasterBlogContext _context;


        public ArticleCategoryRepository(MasterBlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
