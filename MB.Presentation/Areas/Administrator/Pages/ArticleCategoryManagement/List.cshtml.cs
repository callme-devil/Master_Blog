using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(bool created = false)
        {
            ViewData["Created"] = created;
            ArticleCategories = _articleCategoryApplication.List();
        }
    }
}
