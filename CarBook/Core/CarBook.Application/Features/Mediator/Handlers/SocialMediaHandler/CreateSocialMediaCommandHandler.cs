using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaRepository.CreateAsync(new SocialMedia
            {
                Name = request.Name,
                Icon = request.Icon,
                url = request.url
            });
        }
    }
}
