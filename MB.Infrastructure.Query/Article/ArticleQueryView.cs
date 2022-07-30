using MB.Infrastructure.Query.Article.Comment;

namespace MB.Infrastructure.Query.Article
{
    public class ArticleQueryView
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string ArticleCategory { get; set; }

        public string CreationDate { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }

        public int CommentsCount { get; set; }

        public List<CommentQueryView> Comments { get; set; }
    }
}