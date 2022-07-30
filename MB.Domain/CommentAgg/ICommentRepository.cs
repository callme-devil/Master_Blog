using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);

        void Save();

        List<CommentViewModel> GetList();

        Comment Get(long id);

    }
}
