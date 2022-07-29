using System.Globalization;
using MB.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBlogContext _context;

    public ArticleQuery(MasterBlogContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Include(x => x.ArticleCategory).Where(x=>x.IsDeleted == false).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            Image = x.Image
        }).ToList();
    }

    public ArticleQueryView GetArticle(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            Image = x.Image,
            Content = x.Content
        }).First(x=>x.Id == id);
    }
}