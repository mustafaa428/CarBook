using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandler
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IRepository<Review> _repository;

        public GetReviewByCarIdQueryHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetQueryable()
                                         .Where(x => x.CarId == request.Id)
                                         .Select(x => new GetReviewByCarIdQueryResult
                                         {
                                             CarId = x.CarId,
                                             Comment = x.Comment,
                                             CustomerImage = x.CustomerImage,
                                             CustomerName = x.CustomerName,
                                             ReviewDate = x.ReviewDate,
                                             RaitingValue = x.RaitingValue,
                                             ReviewId = x.ReviewId
                                         })
                                         .ToListAsync(cancellationToken);

            return value; // null olabilir
        }
    }
}
