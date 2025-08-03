using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}
