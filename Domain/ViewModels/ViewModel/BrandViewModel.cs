using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.ViewModel
{
    public class BrandViewModel
    {
        public BrandViewModel()
        {
            Description = string.Empty; 
        }

        [Required(ErrorMessage = "Codigo não pode ser vazio.")] public int Code { get; set; }
        [Required(ErrorMessage = "Descrição não pode ser vazio.", AllowEmptyStrings = false)] public string Description { get; set; }
    }
}