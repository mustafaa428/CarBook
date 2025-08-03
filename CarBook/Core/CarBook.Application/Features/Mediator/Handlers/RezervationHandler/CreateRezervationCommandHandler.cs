using CarBook.Application.Features.Mediator.Commands.RezervationCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.RezervationHandler
{
    public class CreateRezervationCommandHandler : IRequestHandler<CreateRezervationCommand>
    {
        private readonly IRepository<Rezervation> _repository;

        public CreateRezervationCommandHandler(IRepository<Rezervation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRezervationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Rezervation
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                DriverLicanseYear = request.DriverLicanseYear,
                DropOffLocationId = request.DropOffLocationId,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationId = request.PickUpLocationId,
                Surname = request.Surname,
                Status = "Rezervasyon alındı"
            });
        }
    }
}
