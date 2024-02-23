using FluentValidation;
using PublisherComplexWeb.Application.Dto.Format;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Format
{
    public class CreateFormatValidator : AbstractValidator<CreateFormatDto>
    {
        public CreateFormatValidator()
        {
            RuleFor(x => x.Title)
              .NotEmpty().WithMessage("Введите название формата")
              .MinimumLength(3).WithMessage("Название формата короткое");
        }
    }
}
