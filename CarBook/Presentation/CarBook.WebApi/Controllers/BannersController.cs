using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler,
                                 CreateBannerCommandHandler createBannerCommandHandler,
                                 UpdateBannerCommandHandler updateBannerCommandHandler,
                                 RemoveBannerCommandHandler removeBannerCommandHandler,
                                 GetBannerQueryHandler getBannerQueryHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanners()
        {
            var result = await _getBannerQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var result = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Bilgi eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner([FromBody] UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Bilgi güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Bilgi silindi");
        }
    }
}
