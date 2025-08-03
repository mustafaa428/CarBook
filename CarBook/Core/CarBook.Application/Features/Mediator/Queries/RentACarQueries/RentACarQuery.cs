using CarBook.Application.Features.Mediator.Results.RentACarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class RentACarQuery : IRequest<List<RentACarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }
    }
}
