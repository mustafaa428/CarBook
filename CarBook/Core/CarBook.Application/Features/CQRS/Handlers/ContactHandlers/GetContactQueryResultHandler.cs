using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryResultHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactQueryResultHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _contactRepository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject,
            }).ToList();
        }
    }
}
