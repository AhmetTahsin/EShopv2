using System.ComponentModel.DataAnnotations;

namespace EShop.COREMVC.Models.PageModels.LoginUserModels
{
    public class UserLoginRequestModel
    {
        [Required(ErrorMessage = "Boş geçemezsin")]
        [MinLength(6, ErrorMessage = "Minimum 6 karakter !!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Boş geçemezsin")]
        [MinLength(6, ErrorMessage = "Minimum 6 karakter !!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
