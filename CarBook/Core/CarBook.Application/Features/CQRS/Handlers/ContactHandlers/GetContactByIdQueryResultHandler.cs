using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryResultHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactByIdQueryResultHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _contactRepository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Email = values.Email,
                Message = values.Message,
                Name = values.Name,
                SendDate = values.SendDate,
                Subject = values.Subject,
            };
        }
    }
}
