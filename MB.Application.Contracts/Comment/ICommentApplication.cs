namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
         void Add(AddComment command);

         List<CommentViewModel> GetList();

         void Confirm(int id);

         void Cancel(int id);
    }
}
