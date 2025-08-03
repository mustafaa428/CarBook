using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetBlogsWithAuthorQueryResultHandler : IRequestHandler<GetBlogsWithAuthorQuery, List<GetBlogsWithAuthorQueryResult>>
    {

        private readonly IRepository<Blog> _repository;

        public GetBlogsWithAuthorQueryResultHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        //private readonly IBlogRepository _repository;

        //public GetBlogsWithAuthorQueryResultHandler(IBlogRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<List<GetBlogsWithAuthorQueryResult>> Handle(GetBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetQueryable().Include(x => x.Author).Include(y => y.Category).ToListAsync();
            return values.Select(x => new GetBlogsWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreateTime = x.CreateTime,
                Title = x.Title,
                Description = x.Description,
            }).ToList();


            //var values = await _repository.GetAllBlogsAuthors();
            //return values.Select(x => new GetBlogsWithAuthorQueryResult
            //{
            //    AuthorId = x.AuthorId,
            //    AuthorName = x.Author.Name,
            //    BlogId = x.BlogId,
            //    CategoryId = x.CategoryId,
            //    CategoryName = x.Category.Name,
            //    CoverImageUrl = x.CoverImageUrl,
            //    CreateTime = x.CreateTime,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToList();
        }
    }


}
