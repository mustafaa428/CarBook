using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetLast5CarWithBrandQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        //private readonly ICarRepository _repository;

        //public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<GetCarWithBrandResult>> Handle()
        {
            var values = await _repository.GetQueryable().Include(_c => _c.Brand).OrderByDescending(x => x.CarId).Take(3).ToListAsync();
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

            //var value = _repository.GetLast5CarsWithBrand();
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
