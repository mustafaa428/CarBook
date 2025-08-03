using CareBook.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        Task<List<RentACar>> GetByIdAsync(Expression<Func<RentACar, bool>> filter);
    }
}
