using PublisherComplexWeb.Application.Dto.Work;

namespace PublisherComplexWeb.Application.Dto.Material
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DeviceId { get; set; }
        public string DeviceTitle { get; set; }

        public virtual ICollection<WorkCollectionDto> Works { get; } = new List<WorkCollectionDto>();
    }
}
