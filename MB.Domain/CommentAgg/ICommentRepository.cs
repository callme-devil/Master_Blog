using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository :IRepository<long , Comment>
    {
        //?Customization Methods

        List<CommentViewModel> GetList();
    }
}
