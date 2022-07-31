﻿using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
        }

        public List<CommentViewModel> GetList()
        {
           return _commentRepository.GetList();
        }

        public void Confirm(int id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            //_commentRepository.Create();
        }

        public void Cancel(int id)
        {
            var comment = _commentRepository.Get(id);
            comment.Canceled();
            //_commentRepository.Save();
        }
    }
}
