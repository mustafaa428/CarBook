using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetLast3BlogsAuthorsQueryResultHandler : IRequestHandler<GetLast3BlogsAuthorsQuery, List<GetLast3BlogsAuthorsQueryResult>>
    {

        private readonly IRepository<Blog> _repository;

        public GetLast3BlogsAuthorsQueryResultHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        //private readonly IBlogRepository _repository;

        //public GetLast3BlogsAuthorsQueryResultHandler(IBlogRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<GetLast3BlogsAuthorsQueryResult>> Handle(GetLast3BlogsAuthorsQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetQueryable().Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();
            return values.Select(x => new GetLast3BlogsAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreateTime = x.CreateTime,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Description = x.Description,
            }).ToList();

            //var values = await _repository.GetLast3BlogsAuthors();
            //return values.Select(x => new GetLast3BlogsAuthorsQueryResult
            //{
            //    AuthorId = x.AuthorId,
            //    BlogId = x.BlogId,
            //    CategoryId = x.CategoryId,
            //    CoverImageUrl = x.CoverImageUrl,
            //    CreateTime = x.CreateTime,
            //    Title = x.Title,
            //    AuthorName = x.Author.Name,
            //    Description = x.Description,
            //}).ToList();
        }

    }
}
