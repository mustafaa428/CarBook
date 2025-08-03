using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutQureyHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQureyHandler _getAllAboutsQueryHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler,
            UpdateAboutCommandHandler updateAboutCommandHandler,
            RemoveAboutCommandHandler removeAboutCommandHandler,
            GetAboutQureyHandler getAboutQueryHandler,
            GetAboutByIdQureyHandler getAllAboutsQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _getAllAboutsQueryHandler = getAllAboutsQueryHandler;
        }


        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var result = await _getAboutQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AboutById(int id)
        {
            var result = await _getAllAboutsQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Hakkızımda bilgisi eklendi");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi güncellendi");
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi silindi");
        }
    }
}
