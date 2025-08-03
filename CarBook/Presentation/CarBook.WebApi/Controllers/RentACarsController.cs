using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> RentACarListByLocation(int LocationId, bool Available)
        {
            RentACarQuery query = new RentACarQuery()
            {
                LocationId = LocationId,
                Available = Available
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
