using CareBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsAuthors();
        Task<List<Blog>> GetAllBlogsAuthors();
        Task<List<Blog>> GetBlogByAuthorId(int id);
    }
}
