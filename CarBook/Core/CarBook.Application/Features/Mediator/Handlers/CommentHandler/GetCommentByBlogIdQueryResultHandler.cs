using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandler
{
    public class GetCommentByBlogIdQueryResultHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByBlogIdQueryResultHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable().Where(x => x.BlogId == request.Id).ToListAsync();
            return values.Select(x => new GetCommentByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                CommentId = x.CommentId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
            }).ToList();

        }
    }
}
