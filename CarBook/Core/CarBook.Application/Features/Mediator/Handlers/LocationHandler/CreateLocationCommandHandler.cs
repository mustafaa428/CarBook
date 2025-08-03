using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public CreateTagCloudCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationRepository.CreateAsync(new Location
            {
                Name = request.Name,
            });
        }
    }
}
