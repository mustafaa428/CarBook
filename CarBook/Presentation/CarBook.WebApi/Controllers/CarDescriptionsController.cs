using CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba açıklaması eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarDescription(UpdateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba özelliği güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarDescription(int id)
        {
            await _mediator.Send(new RemoveCarDescriptionCommand(id));
            return Ok("Araba özelliği silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDescriptionById(int id)
        {
            var values = await _mediator.Send(new GetCarDescriptionQuery(id));
            return Ok(values);
        }
    }
}
