namespace PublisherComplexWeb.Blazor.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<MaterialCollection> Materials { get; } = new List<MaterialCollection>();
    }
}
