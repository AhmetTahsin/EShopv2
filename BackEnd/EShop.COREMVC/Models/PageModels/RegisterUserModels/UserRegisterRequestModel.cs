using System.ComponentModel.DataAnnotations;

namespace EShop.COREMVC.Models.PageModels.RegisterUserModels
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "Boş geçemezsin")]
        [MinLength(6, ErrorMessage = "Minimum 6 karakter !!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Boş geçemezsin")]
        [MinLength(6, ErrorMessage = "Minimum 6 karakter !!")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Email adres formatına uygun olmalıdır")]
        public string Email { get; set; }
    }
}
