using PublisherComplexWeb.Application.Dto.TypeWork;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface ITypeWorkService
    {
        Task<IBaseStatus<List<TypeWorkDto>>> GetAll();
        Task<IBaseStatus<TypeWorkDto>> GetById(int id);
        Task<IBaseStatus<TypeWorkDto>> CreateTypeWork(CreateTypeWorkDto dto);
        Task<IBaseStatus<TypeWorkDto>> UpdateTypeWork(int id, UpdateTypeWorkDto dto);
        Task DeleteTypeWork(int id);
    }
}
