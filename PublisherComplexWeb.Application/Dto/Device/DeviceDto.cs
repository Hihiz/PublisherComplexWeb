using PublisherComplexWeb.Application.Dto.Material;

namespace PublisherComplexWeb.Application.Dto.Device
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<MaterialCollectionDto> Materials { get; } = new List<MaterialCollectionDto>();
    }
}
