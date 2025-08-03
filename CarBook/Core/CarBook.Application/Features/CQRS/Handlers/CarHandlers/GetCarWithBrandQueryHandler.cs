using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarWithBrandQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        //private readonly ICarRepository _repository;

        //public GetCarWithBrandQueryHandler(ICarRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<GetCarWithBrandResult>> Handle()
        {

            var values = await _repository.GetQueryable().Include(c => c.Brand).ToListAsync();
            return values.Select(x => new GetCarWithBrandResult
            {
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
            }).ToList();

            //var value = _repository.GetCarsListWithBrand();
            //return value.Select(x => new GetCarWithBrandResult
            //{
            //    BrandName = x.Brand.Name,
            //    BigImageUrl = x.BigImageUrl,
            //    BrandId = x.BrandId,
            //    CarId = x.CarId,
            //    CoverImageUrl = x.CoverImageUrl,
            //    Fuel = x.Fuel,
            //    Km = x.Km,
            //    Luggage = x.Luggage,
            //    Model = x.Model,
            //    Seat = x.Seat,
            //    Transmission = x.Transmission,
            //}).ToList();
        }
    }
}
