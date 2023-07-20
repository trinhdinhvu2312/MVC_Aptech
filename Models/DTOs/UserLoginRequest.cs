﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Aptech.Models.DTOs
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 character long")]
        public string? Password { get; set; }
    }
}
