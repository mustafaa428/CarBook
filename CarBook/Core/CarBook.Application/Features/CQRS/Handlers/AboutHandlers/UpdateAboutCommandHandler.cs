using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.AboutId);
            about.Title = command.Title;
            about.Description = command.Description;
            about.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(about);

        }
    }
}
