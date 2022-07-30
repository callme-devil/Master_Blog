using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments { get; set; }

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }



        public void OnGet(bool confirmed = false , bool canceled = false)
        {
            ViewData["Confirmed"] = confirmed;
            ViewData["Canceled"] = canceled;

            Comments = _commentApplication.GetList();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List", new { Confirmed = "True" });
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List", new { Canceled = "True" });
        }
    }
}
