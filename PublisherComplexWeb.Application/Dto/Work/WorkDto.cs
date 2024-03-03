namespace PublisherComplexWeb.Application.Dto.Work
{
    public class WorkDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int TypeWorkId { get; set; }
        public string TypeWorkTitle { get; set; }

        public int MaterialId { get; set; }
        public string MaterialTitle { get; set; }

        public int FormatId { get; set; }
        public string FormatTitle { get; set; }

        public string DoublePrint { get; set; }
        public int? Quantity { get; set; }
        public string StatusWork { get; set; }
    }
}
