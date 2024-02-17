namespace PublisherComplexWeb.Domain.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public virtual ICollection<Work> Works { get; } = new List<Work>();
    }
}
