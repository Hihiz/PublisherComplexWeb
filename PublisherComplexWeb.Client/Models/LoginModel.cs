using System.ComponentModel.DataAnnotations;

namespace PublisherComplexWeb.Client.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Логин")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
    }
}
