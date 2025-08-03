using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class GetTagCloudQueryResultHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _locationRepository;

        public GetTagCloudQueryResultHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                Name = x.Name,
            }).ToList();
        }
    }
}
