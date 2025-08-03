using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryResultHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {

        private readonly IRepository<CarFeature> _repository;

        public GetCarFeatureByCarIdQueryResultHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        //private readonly ICarFeatureRepository _repository;

        //public GetCarFeatureByCarIdQueryResultHandler(ICarFeatureRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable().Include(y => y.Feature).Where(x => x.CarId == request.Id).ToListAsync();
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available = x.Available,
                CarId = x.CarId,
                CarFeatureId = x.CarFeatureId,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature.Name
            }).ToList();

            //var values = await _repository.GetCarFeaturesByCarIdAsync(request.Id);
            //return values.Select(x=>new GetCarFeatureByCarIdQueryResult
            //{
            //    Available = x.Available,
            //    CarId = x.CarId,
            //    CarFeatureId = x.CarFeatureId,
            //    FeatureId = x.FeatureId,
            //    FeatureName = x.Feature.Name
            //}).ToList();
        }
    }
}
