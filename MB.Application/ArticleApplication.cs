using _01_Framework.Infrastructure.UnitOfWork;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication :IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetArticles();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId , _articleValidatorService);

            _articleRepository.Create(article);

            _unitOfWork.CommitTran(); //!SaveChanges();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);

            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content , command.ArticleCategoryId );
            _unitOfWork.CommitTran();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                Image = article.Image,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
           var article = _articleRepository.Get(id);
           article.Remove();
           _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }
    }
}
