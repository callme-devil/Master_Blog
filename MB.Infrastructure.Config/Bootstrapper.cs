using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore.Context;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Config
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            #region ArticleCategoryId

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            #endregion

            #region Validators

            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            #endregion

            services.AddDbContext<MasterBlogContext>(x => x.UseSqlServer(connectionString));

            #region Article

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            #endregion

        }
    }
}