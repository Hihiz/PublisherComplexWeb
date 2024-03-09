using FluentValidation;
using PublisherComplexWeb.Application.Dto.TypeWork;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.TypeWork
{
    public class CreateTypeWorkValidator : AbstractValidator<CreateTypeWorkDto>
    {
        public CreateTypeWorkValidator()
        {
            RuleFor(x => x.Title)
                     .NotEmpty().WithMessage("Введите тип работы")
                     .MinimumLength(3).WithMessage("Название типа работы короткое");
        }
    }
}
