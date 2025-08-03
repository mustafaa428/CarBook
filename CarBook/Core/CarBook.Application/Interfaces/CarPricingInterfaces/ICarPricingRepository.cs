using CarBook.Application.ViewModel;
using CareBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarsWithPricings();
        Task<List<CarPricing>> GetCarPricingWithTimePeriod();
        Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1();
    }
}
