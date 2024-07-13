namespace PublisherComplexWeb.Application.Interfaces.Services
{
    public interface IUserService<T>
    {
        Task<T> GetUserOrder();
    }
}