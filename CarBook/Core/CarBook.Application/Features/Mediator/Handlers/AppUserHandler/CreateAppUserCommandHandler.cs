using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CareBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandler
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            // Önce kullanıcı adı var mı kontrol et
            bool userExists = await _repository.GetQueryable()
                .AnyAsync(x => x.Username == request.Username, cancellationToken);

            if (userExists)
            {
                // Kullanıcı varsa hata fırlatabiliriz
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
            }

            // Yoksa kullanıcı oluştur
            await _repository.CreateAsync(new AppUser
            {
                Username = request.Username,
                password = request.Password,
                AppRoleId = (int)UserRoles.Member,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            });
        }
    }
}
