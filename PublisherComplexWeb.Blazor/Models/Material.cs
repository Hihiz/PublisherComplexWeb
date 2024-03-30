namespace PublisherComplexWeb.Blazor.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DeviceId { get; set; }
        public string DeviceTitle { get; set; }

        public virtual ICollection<WorkCollection> Works { get; } = new List<WorkCollection>();
    }
}
