using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogId);
            values.CreateTime = request.CreateTime;
            values.CategoryId = request.CategoryId;
            values.AuthorId = request.AuthorId;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);
        }
    }
}
