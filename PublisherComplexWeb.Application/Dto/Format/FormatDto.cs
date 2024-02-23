using PublisherComplexWeb.Application.Dto.Work;

namespace PublisherComplexWeb.Application.Dto.Format
{
    public class FormatDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<WorkCollectionDto> Works { get; } = new List<WorkCollectionDto>();
    }
}
