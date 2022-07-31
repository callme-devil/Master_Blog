using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService:IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void Validate(string title)
    {
        if (_articleCategoryRepository.Exists(x=>x.Title == title))
        {
            throw new DuplicatedRecordException("This Record Already Exists In DataBase");
        }
    }
}