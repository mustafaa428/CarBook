using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _socialMediaRepository.GetByIdAsync(request.SocailMediaId);
            values.Name = request.Name;
            values.Icon = request.Icon;
            values.url = request.url;
            await _socialMediaRepository.UpdateAsync(values);
        }
    }
}
