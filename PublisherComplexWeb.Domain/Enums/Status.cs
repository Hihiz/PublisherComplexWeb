using System.ComponentModel.DataAnnotations;

namespace PublisherComplexWeb.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Открыт")]
        Open = 1,
        [Display(Name = "Закрыт")]
        Close = 2
    }
}
