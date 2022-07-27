using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.Profile
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Укажите возраст")]
        [Range(0, 150, ErrorMessage = "Диапазон возраста должен быть от 0 до 150")]
        public byte Age { get; set; }
        
        [Required(ErrorMessage = "Укажите адрес")]
        [MinLength(5, ErrorMessage = "Минимальная длина должна быть больше 5 символов")] 
        [MaxLength(200, ErrorMessage = "Максимальная длина должна быть меньше 200 символов")]
        public string Address { get; set; }
        
        public string UserName { get; set; }
    }
}