using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class RemoveCarDescriptionCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCarDescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
