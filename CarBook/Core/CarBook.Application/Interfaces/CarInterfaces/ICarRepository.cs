using CareBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrand();
        List<Car> GetLast5CarsWithBrand();
        int GetCarCount();

    }
}
