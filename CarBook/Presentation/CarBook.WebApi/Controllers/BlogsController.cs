using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogGetById(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog silindi");
        }

        [HttpGet("GetLast3BlogsAuthors")]
        public async Task<IActionResult> GetLast3BlogsAuthorsQueryResult()
        {
            var values = await _mediator.Send(new GetLast3BlogsAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("GetAllBlogsAuthors")]
        public async Task<IActionResult> GetAllBlogsAuthors()
        {
            var values = await _mediator.Send(new GetBlogsWithAuthorQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogsByAuthorId/{id}")]
        public async Task<IActionResult> GetBlogsByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }
    }
}
