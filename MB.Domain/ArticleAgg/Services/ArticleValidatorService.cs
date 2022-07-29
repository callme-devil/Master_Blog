using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services;

public class ArticleValidatorService : IArticleValidatorService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleValidatorService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public void ValidateArticle(string title)
    {
        if (_articleRepository.CheckExist(title))
        {
            throw new DuplicatedRecordException("This Record Already Exists In DataBase");
        }
    }
}