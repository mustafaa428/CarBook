using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CarFeatureByCarCommandHandler : IRequestHandler<CarFeatureByCarCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public CarFeatureByCarCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarFeature
            {
                CarId = request.CarId,
                Available = false,
                FeatureId = request.FeatureId,
            });
        }
    }
}
