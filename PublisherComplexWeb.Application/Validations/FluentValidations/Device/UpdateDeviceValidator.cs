using FluentValidation;
using PublisherComplexWeb.Application.Dto.Device;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Device
{
    public class UpdateDeviceValidator : AbstractValidator<UpdateDeviceDto>
    {
        public UpdateDeviceValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Введите название устройства")
                .MinimumLength(3).WithMessage("Название устройства короткое");
        }
    }
}
