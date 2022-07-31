using System.Globalization;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Context;
using MB.Infrastructure.Query.Article.Comment;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query.Article;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBlogContext _context;

    public ArticleQuery(MasterBlogContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Where(x => x.IsDeleted == false)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed)
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
            Content = x.Content,
            Comments = MapComments(x.Comments.Where(f=>f.Status == Statuses.Confirmed)),
            CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed)
        }).First(x => x.Id == id);
    }

    private static List<CommentQueryView> MapComments(IEnumerable<Domain.CommentAgg.Comment> comments)
    {
        return comments.Select(comment => new CommentQueryView
        {
            Name = comment.Name,
            CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
            Message = comment.Message
        }).ToList();
    }
}