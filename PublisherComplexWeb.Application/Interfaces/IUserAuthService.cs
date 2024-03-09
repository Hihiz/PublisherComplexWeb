namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IUserAuthService<T>
    {
        Task<List<T>> GetAuthUsers();
    }
}
