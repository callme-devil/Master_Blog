using MB.Domain.ArticleAgg;
using MB.Infrastructure.EFCore.Context;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBlogContext _context;


        public ArticleRepository(MasterBlogContext context)
        {
            _context = context;
        }


    }
}
