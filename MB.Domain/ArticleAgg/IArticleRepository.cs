using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetArticles();

        void Create(Article entity);

        void Save();

        Article Get(long id);

        bool CheckExist(string title);
    }
}
