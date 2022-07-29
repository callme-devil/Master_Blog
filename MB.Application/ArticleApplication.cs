﻿using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication :IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetArticles();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);

            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);

            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content , command.ArticleCategoryId);
            _articleRepository.Save();
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
    }
}
