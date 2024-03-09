namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IUserService<T>
    {
        Task<List<T>> GetOrdersUserNames(List<T> orderDto);
        Task<T> GetOrderUserName(T orderDto);
    }
}
