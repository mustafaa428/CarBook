using CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CarDescriptionId);
            values.CarId = request.CarId;
            values.Detail = request.Detail;
            await _repository.UpdateAsync(values);
        }
    }
}
