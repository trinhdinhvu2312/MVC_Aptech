﻿namespace MVC_Aptech.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? EncryptedPassword { get; set; }
    }
}
