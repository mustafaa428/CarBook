using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var banner = await _repository.GetAllAsync();
            return banner.Select(b => new GetBannerQueryResult
            {
                BannerId = b.BannerId,
                Title = b.Title,
                Description = b.Description,
                VidepDescription = b.VidepDescription,
                VideoUrl = b.VideoUrl
            }).ToList();
        }
    }
}
