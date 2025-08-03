using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQureyHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQureyHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQureyResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(a => new GetAboutQureyResult
            {
                AboutId = a.AboutId,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
        }
    }
}
