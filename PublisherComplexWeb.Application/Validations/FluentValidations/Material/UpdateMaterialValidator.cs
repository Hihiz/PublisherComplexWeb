using FluentValidation;
using PublisherComplexWeb.Application.Dto.Material;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Material
{
    public class UpdateMaterialValidator : AbstractValidator<UpdateMaterialDto>
    {
        public UpdateMaterialValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Введите название материала")
                .MinimumLength(3).WithMessage("Название материала короткое");
            RuleFor(x => x.DeviceId)
                 .NotEmpty().WithMessage("Устройство пустое")
                 .GreaterThan(0).WithMessage("Выберите устройство");
        }
    }
}
