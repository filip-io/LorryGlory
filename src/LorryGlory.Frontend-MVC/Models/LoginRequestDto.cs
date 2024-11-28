using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.Models
{
    public class LoginRequestDto
    {
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
        public string? TwoFactorCode { get; init; }

        public string? TwoFactorRecoveryCode { get; init; }
    }
}
