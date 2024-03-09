using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateEnd { get; set; }
        public Status StatusOrder { get; set; }

        public virtual ICollection<Work> Works { get; } = new List<Work>();
    }
}
