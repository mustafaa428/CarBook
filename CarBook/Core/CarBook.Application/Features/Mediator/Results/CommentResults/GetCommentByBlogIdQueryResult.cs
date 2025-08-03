namespace CarBook.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentByBlogIdQueryResult
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}
