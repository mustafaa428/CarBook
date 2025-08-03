using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
