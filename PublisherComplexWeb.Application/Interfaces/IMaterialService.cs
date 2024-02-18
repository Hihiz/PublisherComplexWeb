using PublisherComplexWeb.Application.Dto.Material;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IMaterialService
    {
        Task<IBaseStatus<List<MaterialDto>>> GetAll();
        Task<IBaseStatus<MaterialDto>> GetById(int id);
        Task<IBaseStatus<MaterialDto>> CreateMaterial(CreateMaterialDto dto);
        Task<IBaseStatus<MaterialDto>> UpdateMaterial(int id, UpdateMaterialDto dto);
        Task DeleteMaterial(int id);
    }
}
