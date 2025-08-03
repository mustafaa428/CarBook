using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionQueryResult>
    {
        private readonly IRepository<CarDescription> _repository;

        public GetCarDescriptionQueryHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetQueryable()
                                         .Where(x => x.CarId == request.Id)
                                         .Select(x => new GetCarDescriptionQueryResult
                                         {
                                             CarDescriptionId = x.CarDescriptionId,
                                             CarId = x.CarId,
                                             Detail = x.Detail
                                         })
                                         .FirstOrDefaultAsync(cancellationToken);

            return value; // null olabilir
        }
    }

}
