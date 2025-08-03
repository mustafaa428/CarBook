using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public RemoveTagCloudCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetByIdAsync(request.Id);
            await _locationRepository.RemoveAsync(values);
        }
    }
}
