using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryResultHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryResultHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _categoryRepository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Name = x.Name,
                CategoryId = x.CategoryId,
            }).ToList();
        }
    }
}
