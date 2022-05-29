using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.User
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        
        [Display(Name = "Роль")]
        public string Role { get; set; }
        
        [Display(Name = "Логин")]
        public string Name { get; set; }
        
        [Display(Name = "Возраст")]
        public short Age { get; set; }
        
        [Display(Name = "Адресс")]
        public string Address { get; set; }
    }
}