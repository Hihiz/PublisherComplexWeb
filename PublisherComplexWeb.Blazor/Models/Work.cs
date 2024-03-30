namespace PublisherComplexWeb.Blazor.Models
{
    public class Work
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int TypeWorkId { get; set; }
        public string TypeWorkTitle { get; set; }

        public int MaterialId { get; set; }
        public string MaterialTitle { get; set; }

        public int DeviceId { get; set; }
        public string DeviceTitle { get; set; }

        public int FormatId { get; set; }
        public string FormatTitle { get; set; }

        public string DoublePrint { get; set; }
        public int? Quantity { get; set; }
        public string StatusWork { get; set; }
    }
}
