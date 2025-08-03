using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModel;
using CarBook.Persistence.Context;
using CareBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositoies.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<List<CarPricing>> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1()
        {
            var result = new List<CarPricingViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
            SELECT * FROM
            (
                SELECT 
                    b.Name AS BrandName,
                    c.CoverImageUrl,
                    c.Model,
                    cp.PricingId,
                    cp.Amount
                FROM CarPricings cp
                INNER JOIN Cars c ON c.CarId = cp.CarId
                INNER JOIN Brands b ON b.BrandId = c.BrandId
            ) AS SourceTable
            PIVOT
            (
                SUM(Amount) FOR PricingId IN ([1], [3], [4])
            ) AS PivotTable;";

                command.CommandType = System.Data.CommandType.Text;

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var carPricingViewModel = new CarPricingViewModel
                        {
                            CoverImageUrl = reader.GetString(1),
                            name = reader.GetString(0),
                            Model = reader.GetString(2),
                            Amounts = new List<decimal>(),


                        };

                        // 2,3,4 indexler decimal sütunlar
                        for (int i = 3; i <= 5; i++)
                        {
                            if (reader.IsDBNull(i))
                                carPricingViewModel.Amounts.Add(0);
                            else
                                carPricingViewModel.Amounts.Add(reader.GetDecimal(i));
                        }

                        result.Add(carPricingViewModel);
                    }
                }

                await _context.Database.CloseConnectionAsync();
            }

            return result;
        }


        public async Task<List<CarPricing>> GetCarsWithPricings()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1).ToListAsync();
            return values;
        }
    }
}
/*
public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> result = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM(SELECT Model, PricingId, Amount FROM CarPricings Inner join cars " +
                    "on cars.CarId = CarPricings.CarId INNER join Brands\ton Brands.BrandId =cars.BrandId) " +
                    "As SourceTable Pivot(SUM(Amount) For PricingId In([1], [3], [4])) as pivotTable";
                command.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnectionAsync();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var carPricingViewModel = new CarPricingViewModel();
                        Enumerable.Range(1, 3).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                carPricingViewModel.Amounts.Add(0);
                            }
                            else
                            {
                                carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
                            }
                        });
                        result.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnectionAsync();
                return result;
            }
        }*/