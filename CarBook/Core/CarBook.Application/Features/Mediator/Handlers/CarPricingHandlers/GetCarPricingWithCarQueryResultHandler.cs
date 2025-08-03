using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryResultHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingWithCarQueryResultHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        //private readonly ICarPricingRepository _repository;

        //public GetCarPricingWithCarQueryResultHandler(ICarPricingRepository carRepository)
        //{
        //    _repository = carRepository;
        //}

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable().Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1).ToListAsync();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingId = x.CarPricingId,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarId = x.Car.CarId,
            }).ToList();

            //var values = await _repository.GetCarsWithPricings();
            //return values.Select(x => new GetCarPricingWithCarQueryResult
            //{
            //    Amount = x.Amount,
            //    Brand = x.Car.Brand.Name,
            //    CarPricingId = x.CarPricingId,
            //    CoverImageUrl = x.Car.CoverImageUrl,
            //    Model = x.Car.Model,
            //    CarId = x.Car.CarId,
            //}).ToList();
        }
    }
}
