using FluentValidation;
using PublisherComplexWeb.Application.Dto.Order;

namespace PublisherComplexWeb.Application.Validations.FluentValidations.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.ShortDescription)
              .NotEmpty().WithMessage("Введите краткое описание заказа")
              .MinimumLength(5).WithMessage("Описание заказа слишком маленькое");
        }
    }
}
