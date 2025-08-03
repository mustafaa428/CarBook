using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validator.ReviewValidator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewListByCarId(int id)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidator validation = new CreateReviewValidator();
            var validationResult = validation.Validate(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(command);
            return Ok("Değerlendirme eklendi");
        }
    }
}
