namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<T> GetById(int id, CancellationToken cancellationToken);
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}