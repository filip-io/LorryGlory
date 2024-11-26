using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
