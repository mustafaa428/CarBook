using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand : IRequest
    {
        public int CarId { get; set; }
        public string Detail { get; set; }
    }
}
