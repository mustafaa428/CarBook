using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı kaydı gerçekleşti");
        }
    }
}
