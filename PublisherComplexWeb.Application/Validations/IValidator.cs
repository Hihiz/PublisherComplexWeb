using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Application.Validations
{
    public interface IValidator<T>
    {
        Task<IBaseStatus> Validate(T entity);
    }
}
