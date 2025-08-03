using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithTimePeriod1();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
            {
                BrandName = x.name,
                Model = x.Model,
                DailyAmount = x.Amounts[0],
                WeeklyAmount = x.Amounts[1],
                monthlyAmount = x.Amounts[2],
                CoverImageUrl = x.CoverImageUrl,
            }).ToList();
        }
    }
}
