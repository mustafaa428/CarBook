namespace CarBook.Dto.BlogDtos
{
    public class GetLast3BlogsAuthorDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public int CategoryId { get; set; }
    }
}
