using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.SaveViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Language = EnumLanguage.Portuguese;
        }

        [Required(ErrorMessage = "Nome nao pode ser vazio.", AllowEmptyStrings = false)] public string Name { get; set; }
        [Required(ErrorMessage = "Email nao pode ser vazio.", AllowEmptyStrings = false)] public string Email { get; set; }
        public string Password { get; set; }
        public EnumLanguage Language { get; set; }
    }
}