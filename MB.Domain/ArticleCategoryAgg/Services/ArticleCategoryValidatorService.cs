using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService:IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public void Validate(string title)
    {
        if (_articleCategoryRepository.CheckExist(title))
        {
            throw new DuplicatedRecordException("This Record Already Exists In DataBase");
        }
    }
}