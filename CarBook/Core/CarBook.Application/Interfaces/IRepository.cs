using System.Linq.Expressions;

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        IQueryable<T> GetQueryable();
        Task<T?> GetFilterAsync(Expression<Func<T, bool>> filter);

    }
}
