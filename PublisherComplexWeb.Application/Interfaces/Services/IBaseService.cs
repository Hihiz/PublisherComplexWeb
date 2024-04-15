namespace PublisherComplexWeb.Application.Interfaces.Services
{
    public interface IBaseService<T, TCreateDto, TUpdateDto>
    {
        Task<IBaseStatus<List<T>>> GetAll();
        Task<IBaseStatus<T>> GetById(int id);
        Task<IBaseStatus<T>> Create(TCreateDto dto);
        Task<IBaseStatus<T>> Update(int id, TUpdateDto dto);
        Task Delete(int id);
    }
}
