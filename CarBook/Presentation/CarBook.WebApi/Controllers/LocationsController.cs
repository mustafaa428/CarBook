using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Hem Admin hem Member görebilir
    [HttpGet]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetLocationList()
    {
        var values = await _mediator.Send(new GetLocationQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetLocationGetById(int id)
    {
        var values = await _mediator.Send(new GetLocationByIdQuery(id));
        return Ok(values);
    }

    // Sadece Admin ekleyebilir
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Konum eklendi");
    }

    // Sadece Admin güncelleyebilir
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Konum güncellendi");
    }

    // Sadece Admin silebilir
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _mediator.Send(new RemoveLocationCommand(id));
        return Ok("Konum silindi");
    }
}
