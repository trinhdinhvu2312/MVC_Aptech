using System.ComponentModel.DataAnnotations;

namespace MVC_Aptech.Models.DTOs
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [MinLength(3, ErrorMessage = "FullName must be at least 3 character long")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 character long")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Confirm password must match the password")]
        public string? ConfirmPassword { get; set; }
    }
}
