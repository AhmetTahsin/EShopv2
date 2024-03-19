using System.ComponentModel.DataAnnotations;

namespace EShop.COREMVC.Models.PageModels.NewPasswordUserModels
{
    public class NewPasswordViewModel
    {
        public int userId  { get; set; }
        public string token  { get; set; }

        [Required(ErrorMessage = "Boş geçemezsin")]
        [MinLength(6, ErrorMessage = "Minimum 6 karakter !!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş geçemezsin")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
