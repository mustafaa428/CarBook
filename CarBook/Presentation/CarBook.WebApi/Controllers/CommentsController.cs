using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var values = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return Ok("Yorum güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Yorum silindi");
        }

        [HttpGet("GetCommentByBlogId/{id}")]
        public async Task<IActionResult> GetCommentByBlogId(int id)
        {
            var values = await _mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return Ok("yorum eklendi");
        }
    }
}
