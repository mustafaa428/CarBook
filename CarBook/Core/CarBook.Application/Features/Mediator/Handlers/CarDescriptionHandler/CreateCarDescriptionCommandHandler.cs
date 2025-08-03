using CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarDescription
            {
                CarId = request.CarId,
                Detail = request.Detail,
            });
        }
    }
}
