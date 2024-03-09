using PublisherComplexWeb.Application.Dto.Format;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IFormatService
    {
        Task<IBaseStatus<List<FormatDto>>> GetAll();
        Task<IBaseStatus<FormatDto>> GetById(int id);
        Task<IBaseStatus<FormatDto>> CreateFormat(CreateFormatDto dto);
        Task<IBaseStatus<FormatDto>> UpdateFormat(int id, UpdateFormatDto dto);
        Task DeleteFormat(int id);
    }
}
