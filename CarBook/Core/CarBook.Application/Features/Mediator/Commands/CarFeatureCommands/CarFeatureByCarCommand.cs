using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CarFeatureByCarCommand : IRequest
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
