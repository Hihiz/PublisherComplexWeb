using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Domain.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int TypeWorkId { get; set; }
        public TypeWork TypeWork { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string DoublePrint { get; set; }
        public int FormatId { get; set; }
        public int? Quantity { get; set; }
        public Status StatusWork { get; set; }
    }
}
