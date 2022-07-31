﻿using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository :IRepository<int , Comment>
    {
        //?Customization Methods

        List<CommentViewModel> GetList();
    }
}
