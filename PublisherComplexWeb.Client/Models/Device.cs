namespace PublisherComplexWeb.Client.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<MaterialCollection> Materials { get; } = new List<MaterialCollection>();
    }
}
