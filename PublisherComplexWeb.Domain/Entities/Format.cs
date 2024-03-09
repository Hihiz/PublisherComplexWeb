namespace PublisherComplexWeb.Domain.Entities
{
    public class Format
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Work> Works { get; } = new List<Work>();
    }
}
