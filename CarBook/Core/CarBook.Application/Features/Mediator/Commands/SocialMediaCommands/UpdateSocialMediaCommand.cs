using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int SocailMediaId { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public string Icon { get; set; }
    }
}
