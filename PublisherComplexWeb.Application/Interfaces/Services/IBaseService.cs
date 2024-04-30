namespace PublisherComplexWeb.Application.Interfaces.Services
{
    public interface IBaseService<T, TCreateDto, TUpdateDto>
    {
        Task<IBaseStatus<List<T>>> GetAll(CancellationToken cancellationToken);
        Task<IBaseStatus<T>> GetById(int id, CancellationToken cancellationToken);
        Task<IBaseStatus<T>> Create(TCreateDto dto, CancellationToken cancellationToken);
        Task<IBaseStatus<T>> Update(int id, TUpdateDto dto, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
