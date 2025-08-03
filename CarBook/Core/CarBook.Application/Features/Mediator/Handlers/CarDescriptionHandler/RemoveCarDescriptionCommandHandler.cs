using CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class RemoveCarDescriptionCommandHandler : IRequestHandler<RemoveCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public RemoveCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
