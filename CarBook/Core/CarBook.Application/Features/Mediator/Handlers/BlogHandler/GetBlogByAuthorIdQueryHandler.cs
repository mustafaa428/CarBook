using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByAuthorIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        //private readonly IBlogRepository _blogRepository;

        //public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        //{
        //    _blogRepository = blogRepository;
        //}

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable().Include(x => x.Author).Where(y => y.AuthorId == request.Id).ToListAsync();
            return values.Select(x => new GetBlogByAuthorIdQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                BlogId = x.BlogId,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
            }).ToList();


            //var values = await _blogRepository.GetBlogByAuthorId(request.Id);
            //return values.Select(x => new GetBlogByAuthorIdQueryResult
            //{
            //    AuthorId = x.AuthorId,
            //    AuthorName = x.Author.Name,
            //    BlogId = x.BlogId,
            //    AuthorDescription = x.Author.Description,
            //    AuthorImageUrl = x.Author.ImageUrl,
            //}).ToList();
        }
    }
}
