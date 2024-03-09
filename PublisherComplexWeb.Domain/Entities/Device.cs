namespace PublisherComplexWeb.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Material> Materials { get; } = new List<Material>();
    }
}
