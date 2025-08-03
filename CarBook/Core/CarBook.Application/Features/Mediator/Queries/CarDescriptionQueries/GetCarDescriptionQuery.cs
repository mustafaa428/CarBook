using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery : IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionQuery(int id)
        {
            Id = id;
        }
    }
}
