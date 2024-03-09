using FluentValidation;
using PublisherComplexWeb.Application.Dto.Order;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Order
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.ShortDescription)
                .NotEmpty().WithMessage("Введите краткое описание заказа")
                .MinimumLength(5).WithMessage("Описание заказа слишком маленькое");
        }
    }
}
