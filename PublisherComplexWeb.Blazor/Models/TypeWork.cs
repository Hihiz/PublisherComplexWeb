namespace PublisherComplexWeb.Blazor.Models
{
    public class TypeWork
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<WorkCollection> Works { get; } = new List<WorkCollection>();
    }
}
