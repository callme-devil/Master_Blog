using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreationDate { get; private set; }

        public ICollection<Article> Articles { get; set; }

        public ArticleCategory(string title , IArticleCategoryValidatorService validatorService)
        {
            CheckNullableTitle(title);
            validatorService.Validate(title);

            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void CheckNullableTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
        }

        public void Rename(string title)
        {
            CheckNullableTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
