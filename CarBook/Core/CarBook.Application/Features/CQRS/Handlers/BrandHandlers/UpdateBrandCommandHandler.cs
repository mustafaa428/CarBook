using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateBrandCommand command)
        {
            var brand = await _repository.GetByIdAsync(command.BrandId);

            brand.Name = command.Name;
            await _repository.UpdateAsync(brand);
        }

    }
}
