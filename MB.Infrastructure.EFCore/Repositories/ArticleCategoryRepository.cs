using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Context;

namespace MB.Infrastructure.EFCore.Repositories
{
    public  class ArticleCategoryRepository :IArticleCategoryRepository
    {
        private readonly MasterBlogContext _context;


        public ArticleCategoryRepository(MasterBlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            _context.SaveChanges(); 
        }
    }
}
