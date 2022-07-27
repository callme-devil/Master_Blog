namespace MB.Application.Contracts.ArticleCategory
{
    //?CreateArticle Inherited for duplicate reason in create we get title in edit we get title 
    public class RenameArticleCategory :CreateArticleCategory
    {
        public long Id { get; set; }    
    }
}
