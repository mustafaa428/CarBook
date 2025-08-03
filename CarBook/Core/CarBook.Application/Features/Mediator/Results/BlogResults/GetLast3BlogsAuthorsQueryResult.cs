namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogsAuthorsQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }

    }
}
