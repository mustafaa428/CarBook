using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _contactRepository.GetByIdAsync(command.ContactId);
            values.SendDate = command.SendDate;
            values.Email = command.Email;
            values.Subject = command.Subject;
            values.Message = command.Message;
            values.Name = command.Name;
            await _contactRepository.UpdateAsync(values);

        }
    }
}
