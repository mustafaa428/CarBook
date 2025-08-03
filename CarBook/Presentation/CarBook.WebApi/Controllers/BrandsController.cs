using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(RemoveBrandCommandHandler removeBrandCommandHandler,
            CreateBrandCommandHandler createBrandCommandHandler,
            GetBrandQueryHandler getBrandQueryHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler)
        {
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _getBrandQueryHandler.Handler();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var result = await _getBrandByIdQueryHandler.Handler(new GetBrandByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handler(command);
            return Ok("Marka eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handler(command);
            return Ok("Marka güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handler(new RemoveBrandCommand(id));
            return Ok("Marka silindi");
        }
    }
}
