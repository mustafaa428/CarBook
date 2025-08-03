using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryResultHandler : IRequestHandler<RentACarQuery, List<RentACarQueryResult>>
    {
        private readonly IRepository<RentACar> _repository;

        public GetRentACarQueryResultHandler(IRepository<RentACar> repository)
        {
            _repository = repository;
        }

        //private readonly IRentACarRepository _repository;

        //public GetRentACarQueryResultHandler(IRentACarRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<RentACarQueryResult>> Handle(RentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable()
                                          .Include(x => x.Car)
                                          .ThenInclude(y => y.Brand)
                                          .Where(x => x.LocationId == request.LocationId && x.Available == true)
                                           .ToListAsync();
            return values.Select(x => new RentACarQueryResult
            {
                CarId = x.CarId,
                Brand = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model
            }).ToList();

            //var values = await _repository.GetByIdAsync(x => x.LocationId == request.LocationId && x.Available == true);
            //return values.Select(x => new RentACarQueryResult
            //{
            //    CarId = x.CarId,
            //    Brand = x.Car.Brand.Name,
            //    CoverImageUrl = x.Car.CoverImageUrl,
            //    Model = x.Car.Model
            //}).ToList();
        }
    }
}
