using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class ChangeAvailableCommand : IRequest
    {
        public int CarFeatureId { get; set; }
        public bool Available { get; set; }
    }
}
