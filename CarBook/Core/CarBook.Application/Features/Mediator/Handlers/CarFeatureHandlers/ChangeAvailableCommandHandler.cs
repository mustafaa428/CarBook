using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class ChangeAvailableCommandHandler : IRequestHandler<ChangeAvailableCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public ChangeAvailableCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeAvailableCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CarFeatureId);
            if (request.Available == value.Available)
            {
                value.Available = value.Available;
            }
            else
            {
                value.Available = !value.Available;
            }
            await _repository.UpdateAsync(value);
        }
    }
}
