using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {

        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(bool created = false , bool edited = false , bool  activated = false , bool removed =false)
        {
            ViewData["Created"] = created;
            ViewData["Edited"] = edited;
            ViewData["Activated"] = activated;
            ViewData["Removed"] = removed;


            Articles = _articleApplication.GetArticles();
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./List", new { Activated = "True" });
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./List", new { Removed = "True" });

        }
    }
}
