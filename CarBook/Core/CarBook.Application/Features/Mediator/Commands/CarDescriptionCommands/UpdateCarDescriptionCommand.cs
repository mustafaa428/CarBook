using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class UpdateCarDescriptionCommand : IRequest
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string Detail { get; set; }
    }
}
