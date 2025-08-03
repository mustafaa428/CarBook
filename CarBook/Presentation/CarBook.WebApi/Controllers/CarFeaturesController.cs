using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPut("ChangeAvailable")]
        public async Task<IActionResult> ChangeAvailable(ChangeAvailableCommand changeAvailable)
        {
            await _mediator.Send(changeAvailable);
            return Ok("Durum değişti");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(CarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba özelliği eklendi");
        }
    }
}
