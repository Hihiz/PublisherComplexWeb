using FluentValidation;
using PublisherComplexWeb.Application.Dto.Work;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Work
{
    public class CreateWorkValidator : AbstractValidator<CreateWorkDto>
    {
        public CreateWorkValidator()
        {
            RuleFor(x => x.TypeWorkId)
               .NotEmpty().WithMessage("Тип работы не должен быть пустым")
               .GreaterThan(0).WithMessage("Выберите тип работы");
            RuleFor(x => x.MaterialId)
                .NotEmpty().WithMessage("Материал бумаги не должен быть пустым")
                .GreaterThan(0).WithMessage("Выберите материал бумаги");
            RuleFor(x => x.DoublePrint)
                .NotNull().WithMessage("Укажите двустороннюю печать");
            RuleFor(x => x.FormatId)
                .NotEmpty().WithMessage("Формат бумаги не должен быть пустым")
                .GreaterThan(0).WithMessage("Укажите формат бумаги");
        }
    }
}
