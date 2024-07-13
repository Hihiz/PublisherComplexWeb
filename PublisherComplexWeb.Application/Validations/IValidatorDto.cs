namespace PublisherComplexWeb.Application.Validations
{
    public interface IValidatorDto<T>
    {
        Task Validate(T entity);
    }
}
