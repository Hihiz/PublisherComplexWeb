using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Application.Validations
{
    public interface IValidatorDto<T>
    {
        Task<IBaseStatus> Validate(T entity);
    }
}
