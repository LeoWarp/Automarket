using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Укажите возраст")]
        [Range(0, 150, ErrorMessage = "Диапазон возраста должен быть от 0 до 150")]
        public short Age { get; set; }
        
        [Required(ErrorMessage = "Укажите адрес")]
        [MinLength(5, ErrorMessage = "Минимальная длина должна быть больше 5 символов")] 
        [MaxLength(250, ErrorMessage = "Максимальная длина должна быть меньше 250 символов")]
        public string Address { get; set; }
    }
}