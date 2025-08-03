using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; }
        public string url { get; set; }
        public string Icon { get; set; }
    }
}
