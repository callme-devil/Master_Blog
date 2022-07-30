namespace MB.Infrastructure.Query.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();

        ArticleQueryView GetArticle(long id);
    }
}
