using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery : IRequest<List<GetCommentByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
