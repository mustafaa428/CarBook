using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook.Application.Validator.ReviewValidator
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Adınızı boş geçemezsiniz...");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("5 karakterin üzerinde karakter girişi yapınız...");
            RuleFor(x => x.CustomerName).MaximumLength(20).WithMessage("Adınızı 20 karakterden fazla giremezsiniz...");
            RuleFor(x => x.RaitingValue).NotEmpty().WithMessage("Lütfen yıldız puanı veriniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorumunuzu giriniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("En az 20 karakterli değerlendirme yorumunu giriniz");
            RuleFor(x => x.Comment).MaximumLength(150).WithMessage("En fazla 150 karakterli değerlendirme yorumunu giriniz");
        }
    }
}
