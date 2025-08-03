namespace CarBook.Dto.BlogDtos
{
    public class UpdateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
